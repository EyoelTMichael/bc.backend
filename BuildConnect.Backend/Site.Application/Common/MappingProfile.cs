using AutoMapper;
using Site.Application.Features.StaffOnSiteFeature.Command;
using Site.Domain.Entity;

namespace Site.Application.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SiteModel, SiteDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<Permission, PermissionDto>();
        CreateMap<RolePermission, RolePermissionDto>();
        CreateMap<User, UserDto>();
        CreateMap<Material, MaterialDto>();
        CreateMap<MaterialReport, MaterialReportDto>();
        CreateMap<StaffOnSite, StaffOnSiteDto>();
        CreateMap<LabourForce, LabourForceDto>();
        CreateMap<DailyReport, DailyReportDto>();
        CreateMap<CreateStaffOnSiteCommand, StaffOnSiteDto>();
        CreateMap<TaskModel, TaskModelDto>();
    }
}
