using Microsoft.EntityFrameworkCore;
using Site.Domain.Entity;

namespace Site.Application.Common.Interface;



public interface IApplicationDbContext
{
    DbSet<SiteModel> Sites { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Permission> Permissions { get; set; }
    DbSet<RolePermission> RolePermissions { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Material> Materials { get; set; }
    DbSet<MaterialReport> MaterialReports { get; set; }
    public DbSet<StaffOnSite> StaffOnSites { get; set; }
    public DbSet<LabourForce> LabourForces { get; set; }
    public DbSet<DailyReport> DailyReports { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}