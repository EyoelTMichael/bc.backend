﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.MaterialReportFeatures.Command;
using Site.Domain.Entity;

namespace Site.Application.Features.DailyReportFeature.Command;

public class CreateDailyReportCommandCommandHandler : IRequestHandler<CreateDailyReportCommand, DailyReportDto>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateDailyReportCommandCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<DailyReportDto> Handle(CreateDailyReportCommand request, CancellationToken cancellationToken)
    {
        // Create Daily Report
        var dailyReport = new DailyReport
        {
            Date = request.Date,
            WorkHour = request.WorkHour,
            InterruptedHour = request.InterruptedHour,
            Weather = request.Weather,
        };

        _context.DailyReports.Add(dailyReport);
        await _context.SaveChangesAsync(cancellationToken);

        // Create Staff On Site
        foreach (var staffCommand in request.StaffOnSites)
        {
            var staffOnSite = new StaffOnSite
            {
                Position = staffCommand.Position,
                Count = staffCommand.Count,
                DailyReportId = dailyReport.Id,
            };

            _context.StaffOnSites.Add(staffOnSite);
        }

        foreach (var labourCommand in request.LabourForces)
        {
            var labourForce = new LabourForce
            {
                Position = labourCommand.Position,
                Count = labourCommand.Count,
                DailyReportId = dailyReport.Id,
            };

            _context.LabourForces.Add(labourForce);
        }

        foreach (var materialCommand in request.MaterialReports)
        {
            var materialReport = new MaterialReport
            {
                Name = materialCommand.Name,
                Quantity = materialCommand.Quantity,
                DailyReportId = dailyReport.Id,
            };

            _context.MaterialReports.Add(materialReport);
        }


        await _context.SaveChangesAsync(cancellationToken);

        var staffOnSites = await _context.StaffOnSites
            .Where(s => s.DailyReportId == dailyReport.Id)
            .ToListAsync(cancellationToken);

        // Map to DTOs
        var staffOnSiteDtos = _mapper.Map<List<StaffOnSiteDto>>(staffOnSites);

        var labourForces = await _context.LabourForces
            .Where(s => s.DailyReportId == dailyReport.Id)
            .ToListAsync(cancellationToken);

        // Map to DTOs
        var labourForceDtos = _mapper.Map<List<LabourForceDto>>(labourForces);

        var materialsReport = await _context.MaterialReports
            .Where(s => s.DailyReportId == dailyReport.Id)
            .ToListAsync(cancellationToken);

        // Map to DTOs
        var materialReportDtos = _mapper.Map<List<MaterialReportDto>>(materialsReport);


        // Map to DTO
        var dailyReportDto = _mapper.Map<DailyReportDto>(dailyReport);
        dailyReportDto.StaffsOnSite = staffOnSiteDtos;
        dailyReportDto.LabourForces = labourForceDtos;
        dailyReportDto.MaterialsReport = materialReportDtos;

        return dailyReportDto;
    }
}
