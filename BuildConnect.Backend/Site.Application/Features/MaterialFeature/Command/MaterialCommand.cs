using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialFeature.Command;

public class CreateMaterialCommand : IRequest<MaterialDTO>
{
    public string Name { get; set; }
    public string UnitOfMeasure { get; set; }
}

public class UpdateMaterialCommand : IRequest<MaterialDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UnitOfMeasure { get; set; }
}

public class DeleteMaterialCommand : IRequest
{
    public Guid Id { get; set; }
}
