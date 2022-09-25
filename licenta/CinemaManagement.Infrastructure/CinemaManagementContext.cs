using CinemaManagement.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure
{
    public class CinemaManagementContext :IdentityDbContext<User, UserRole, Guid>
    {
        public CinemaManagementContext(DbContextOptions options):base(options)
        {
        }    
        
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ReservedSeat> ReservedSeats { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Session> Sessions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ReservedSeat>().HasOne(s=> s.Seat ).WithMany(s=> s.ReservedSeats).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReservedSeat>().HasOne(s => s.Session).WithMany(s => s.ReservedSeats).OnDelete(DeleteBehavior.NoAction);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreateDate = DateTime.UtcNow;
                }
                else
                {
                    Entry((BaseModel)entityEntry.Entity).Property(p => p.CreateDate).IsModified = false;
                }

                ((BaseModel)entityEntry.Entity).UpdateDate = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
