using MediatR;

namespace Site.Application.Features.MaterialCostFeature.Command;

public class CreateMaterialCostCommand : IRequest<Guid>
{
    public string TypeOfMaterial { get; set; }
    public Guid Unit { get; set; }
    public int Quantity { get; set; }
    public int Rate { get; set; }
    public int CostPerUnit { get; set; }
}

public class UpdateMaterialCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string TypeOfMaterial { get; set; }
    public Guid Unit { get; set; }
    public int Quantity { get; set; }
    public int Rate { get; set; }
    public int CostPerUnit { get; set; }
}

public class DeleteMaterialCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
