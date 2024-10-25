namespace AccessManagement_BackEnd.DAL
{
    using AccessManagement_BackEnd.Classes;
    using Microsoft.EntityFrameworkCore;
    using System.Drawing;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Installation> Installations { get; set; }
        public DbSet<AccessPoint> AccessPoints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AccessRecord> AccessRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación entre Point e Installation (muchos a uno)
            modelBuilder.Entity<AccessPoint>()
                .HasOne(p => p.Installation)
                .WithMany()  // No necesita colección inversa en Installation
                .HasForeignKey(p => p.InstallationId);

            // Relación uno a muchos entre Profile y Permission
            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Permissions)
                .WithOne()
                .HasForeignKey(p => p.AccessPointId);

            // Relación uno a uno entre User y Profile
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithMany()
                .HasForeignKey(u => u.ProfileId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
