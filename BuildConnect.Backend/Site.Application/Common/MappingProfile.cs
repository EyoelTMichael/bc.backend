using AutoMapper;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SiteModel, SiteDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<Permission, PermissionDto>();
        CreateMap<RolePermission, RolePermissionDto>();

        // etc. for other mappings
    }
}
