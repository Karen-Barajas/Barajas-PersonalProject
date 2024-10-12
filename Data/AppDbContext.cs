using Microsoft.EntityFrameworkCore;
using TheMaxieInn.Models;

namespace TheMaxieInn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<DogReservation> DogReservation { get; set; }
        public DbSet<DogOwner> DogOwner { get; set; }
        public DbSet<DogInformation> DogInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DogReservation>()
                .HasKey(r => r.ReservationId);

            modelBuilder.Entity<DogOwner>()
                .HasKey(o => o.OwnerId);

            modelBuilder.Entity<DogInformation>()
                .HasKey(o => o.DogId);

            modelBuilder.Entity<DogOwner>()
                .HasOne(o => o.DogReservation)
                .WithOne(r => r.DogOwner)
                .HasForeignKey<DogOwner>(o => o.ReservationId);

            modelBuilder.Entity<DogInformation>()
                .HasOne(i => i.DogReservation)
                .WithOne(r => r.DogInformation)
                .HasForeignKey<DogInformation>(i => i.ReservationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
