using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialReportFeatures.Command;

public class CreateMaterialReportCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

public class UpdateMaterialReportCommand : IRequest<MaterialReportDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

public class DeleteMaterialReportCommand : IRequest
{
    public Guid Id { get; set; }
}
