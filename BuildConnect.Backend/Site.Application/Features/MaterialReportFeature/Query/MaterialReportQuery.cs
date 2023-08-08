using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialReportFeatures.Query;

public class GetMaterialReportQuery : IRequest<MaterialReportDto>
{
    public Guid Id { get; set; }
}

public class GetAllMaterialReportsQuery : IRequest<IEnumerable<MaterialReportDto>>
{
}

