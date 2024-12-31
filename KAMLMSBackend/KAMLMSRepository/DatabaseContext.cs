using KAMLMSContracts.Entities;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Constants;
using Microsoft.EntityFrameworkCore;

namespace KAMLMSRepository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ManagersEntity> ManagersEntity { get; set; }
        public DbSet<LeadsEntity> LeadsEntity { get; set; }
        public DbSet<ContactEntity> ContactEntity { get; set; }
        public DbSet<RolesEntity> RolesEntity { get; set; }
        public DbSet<CustomRoleEntity> CustomRoleEntity { get; set; }
        public DbSet<LoginEntity> LoginEntities { get; set; }
        public DbSet<LeadStatusEntity> LeadStatusEntity { get; set; }
        public DbSet<DashboardResponse> DashboardResponse { get; set; }
        public DbSet<CallScheduleEntity> CallScheduleEntity { get; set; }
        public DbSet<CallStatusEntity> CallStatusEntity { get; set; }
        public DbSet<CountryEntity> CountryEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ManagersEntity>().HasIndex(m => m.Email).IsUnique();
            modelBuilder.Entity<LoginEntity>().HasIndex(m => m.Email).IsUnique();
            modelBuilder.Entity<RolesEntity>().HasData(
                Enum.GetValues(typeof(Role))
                .Cast<Role>()
                .Select(role => new RolesEntity
                {
                    Id = (int)role,
                    Name = role.ToString()
                })
                );

            modelBuilder.Entity<LeadStatusEntity>().HasData(
                Enum.GetValues(typeof(LeadStatus))
                .Cast<LeadStatus>()
                .Select(status => new LeadStatusEntity
                {
                    id = (int)status,
                    Status = status.ToString()
                }));

            modelBuilder.Entity<CallStatusEntity>().HasData(
                Enum.GetValues(typeof(CallStatusEnum))
                .Cast<CallStatusEnum>()
                .Select(status => new CallStatusEntity
                {
                    Id = (int)status,
                    Status = status.ToString()
                }));

            modelBuilder.Entity<ContactEntity>()
              .HasOne(c => c.LeadsEntity)
              .WithMany()
              .HasForeignKey(c => c.LeadsId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CallScheduleEntity>()
                .HasOne(e => e.ScheduledBy)
                .WithMany()
                .HasForeignKey(e => e.ScheduledById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CallScheduleEntity>()
                .HasOne(e => e.ScheduledWith)
                .WithMany()
                .HasForeignKey(e => e.ScheduledWithId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomRoleEntity>().HasData(
                new CustomRoleEntity { Id = 1, Name = "DEFAULT" });
        }
    }
}
