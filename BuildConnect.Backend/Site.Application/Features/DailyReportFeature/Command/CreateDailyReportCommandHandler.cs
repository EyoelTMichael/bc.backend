using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.DailyReportFeature.Command;

public class CreateDailyReportCommandCommandHandler : IRequestHandler<CreateDailyReportCommand, DailyReportDTO>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateDailyReportCommandCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<DailyReportDTO> Handle(CreateDailyReportCommand request, CancellationToken cancellationToken)
    {
        // Create Daily Report
        var dailyReport = new DailyReport
        {
            Date = request.Date.ToUniversalTime(),
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

        foreach (var equipmentCommand in request.EquipmentReports)
        {
            var equipmentReport = new EquipmentReport
            {
                Name = equipmentCommand.Name,
                WorkHour = equipmentCommand.WorkHour,
                EdleHour = equipmentCommand.EdleHour,
                DailyReportId = dailyReport.Id,
            };

            _context.EquipmentReports.Add(equipmentReport);
        }


        await _context.SaveChangesAsync(cancellationToken);

        var staffOnSites = await _context.StaffOnSites
            .Where(s => s.DailyReportId == dailyReport.Id)
            .ToListAsync(cancellationToken);

        // Map to DTOs
        var staffOnSiteDtos = _mapper.Map<List<StaffOnSiteDTO>>(staffOnSites);

        var labourForces = await _context.LabourForces
            .Where(s => s.DailyReportId == dailyReport.Id)
            .ToListAsync(cancellationToken);

        // Map to DTOs
        var labourForceDtos = _mapper.Map<List<LabourForceDTO>>(labourForces);

        var materialsReport = await _context.MaterialReports
            .Where(s => s.DailyReportId == dailyReport.Id)
            .ToListAsync(cancellationToken);

        // Map to DTOs
        var materialReportDtos = _mapper.Map<List<MaterialReportDTO>>(materialsReport);

        var equipmensReport = await _context.EquipmentReports
            .Where(s => s.DailyReportId == dailyReport.Id)
            .ToListAsync(cancellationToken);

        // Map to DTOs
        var equipmentReportDtos = _mapper.Map<List<EquipmentReportDTO>>(equipmensReport);


        // Map to DTO
        var dailyReportDto = _mapper.Map<DailyReportDTO>(dailyReport);
        dailyReportDto.StaffsOnSite = staffOnSiteDtos;
        dailyReportDto.LabourForces = labourForceDtos;
        dailyReportDto.MaterialsReport = materialReportDtos;
        dailyReportDto.EquipmentReport = equipmentReportDtos;

        return dailyReportDto;
    }
}

