using Microsoft.EntityFrameworkCore;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Infrastructure.Contexts
{
    public class ThreadDbContext : DbContext
    {
        public ThreadDbContext(DbContextOptions<ThreadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThreadDto>().ToTable("threads");
            modelBuilder.Entity<ThreadDto>().HasData(
                new ThreadDto(Guid.NewGuid(), "Does anyone absolutely hate Harry Potter?", "What a bad movie lol", "calin", DateTime.Now, DateTime.Now),
                new ThreadDto(Guid.NewGuid(), "I think Dune was an amazing movie", "kek", "calin", DateTime.Now, DateTime.Now),
                new ThreadDto(Guid.NewGuid(), "Voldemort was an amazing villain wow!", "henry ponmter", "calin", DateTime.Now, DateTime.Now));
        }

        public DbSet<ThreadDto> Threads { get; set; }
    }
}