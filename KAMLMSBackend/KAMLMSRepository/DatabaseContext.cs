using KAMLMSContracts.Entities;
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

            modelBuilder.Entity<ContactEntity>()
              .HasOne(c => c.LeadsEntity)
              .WithMany()  
              .HasForeignKey(c => c.LeadsEntityId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
