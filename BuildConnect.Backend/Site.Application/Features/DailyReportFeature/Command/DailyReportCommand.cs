using MediatR;
using Site.Application.Features.LabourForceFeatures.Command;
using Site.Application.Features.MaterialReportFeatures.Command;
using Site.Application.Features.StaffOnSiteFeature.Command;
using Site.Domain.Entity;


namespace Site.Application.Features.DailyReportFeature.Command;

public class CreateDailyReportCommand : IRequest<DailyReportDto>
{
    public DateTime Date { get; set; }
    public int WorkHour { get; set; }
    public int InterruptedHour { get; set; }
    public string Weather { get; set; }
    public List<CreateStaffOnSiteCommand> StaffOnSites { get; set; }
    public List<CreateLabourForceCommand> LabourForces { get; set; }
    public List<CreateMaterialReportCommand> MaterialReports { get; set; }
}

public class UpdateDailyReportReportCommand : IRequest<DailyReportDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

public class DeleteDailyReportReportCommand : IRequest
{
    public Guid Id { get; set; }
}
