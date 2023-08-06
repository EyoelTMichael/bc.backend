using MediatR;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.MaterialFeature.Command;

public class CreateMaterialCommand : IRequest<MaterialDto>
{
    public string Name { get; set; }
    public string UnitOfMeasure { get; set; }
}

public class UpdateMaterialCommand : IRequest<MaterialDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UnitOfMeasure { get; set; }
}

public class DeleteMaterialCommand : IRequest
{
    public Guid Id { get; set; }
}
