
using MediatR;

namespace Site.Application.Features.EquipmentCostFeature.Command;

public class CreateEquipmentCostCommand : IRequest<Guid>
{
    public Guid Labour { get; set; }
    public int Count { get; set; }
    public int HourlyCost { get; set; }
    public Guid WorkItem { get; set; }
}

public class UpdateEquipmentCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid Labour { get; set; }
    public int Count { get; set; }
    public int HourlyCost { get; set; }
    public Guid WorkItem { get; set; }
}

public class DeleteEquipmentCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}

