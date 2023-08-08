using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialFeatures.Query;

public class GetMaterialQuery : IRequest<MaterialDto>
{
    public Guid Id { get; set; }
}

public class GetAllMaterialsQuery : IRequest<IEnumerable<MaterialDto>>
{
}
