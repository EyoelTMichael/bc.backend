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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}