using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common;
using Site.Domain.Entity;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace Site.Infrastructure.Data;

public class SiteAppDbContext : DbContext, IApplicationDbContext
{
    public SiteAppDbContext(DbContextOptions<SiteAppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType).HasQueryFilter(GetIsNotDeletedExpression(entityType.ClrType));
            }
        }

        builder.Entity<User>()
        .HasOne(u => u.Role)
        .WithMany()
        .HasForeignKey(u => u.RoleId);

        builder.Entity<TaskModel>()
        .HasOne(t => t.AssigneeUser)
        .WithOne()
        .HasForeignKey<TaskModel>(t => t.AssigneeUserId);

        builder.Entity<TaskModel>()
            .HasOne(t => t.AssignedUser)
            .WithOne()
            .HasForeignKey<TaskModel>(t => t.AssignedUserId);
    }

    public DbSet<SiteModel> Sites { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialReport> MaterialReports { get; set; }
    public DbSet<StaffOnSite> StaffOnSites { get; set; }
    public DbSet<LabourForce> LabourForces { get; set; }
    public DbSet<DailyReport> DailyReports { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseModel && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseModel)entityEntry.Entity).UpdatedAt = DateTime.UtcNow; // changed to UtcNow

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseModel)entityEntry.Entity).CreatedAt = DateTime.UtcNow; // changed to UtcNow
            }
        }



        return await base.SaveChangesAsync(cancellationToken);
    }
    private static LambdaExpression GetIsNotDeletedExpression(Type type)
    {
        var parameter = Expression.Parameter(type, "e");
        var body = Expression.Equal(Expression.Property(parameter, nameof(BaseModel.DeletedAt)), Expression.Constant(null));
        return Expression.Lambda(body, parameter);
    }
}
