using MediatR;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.RoleFeatures.Command;

public class AssignPermissionsToRoleCommand : IRequest
{
    public Guid RoleId { get; set; }
    public List<Guid> PermissionIds { get; set; }
}


