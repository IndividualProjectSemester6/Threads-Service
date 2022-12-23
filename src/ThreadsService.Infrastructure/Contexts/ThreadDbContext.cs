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
                new ThreadDto(Guid.NewGuid(),new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"), "Does anyone absolutely hate Harry Potter?", "What a bad movie lol", "calin", DateTime.Now, DateTime.Now),
                new ThreadDto(Guid.NewGuid(), new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"), "I think Dune was an amazing movie", "kek", "calin", DateTime.Now, DateTime.Now),
                new ThreadDto(Guid.NewGuid(), new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"), "Voldemort was an amazing villain wow!", "henry ponmter", "calin", DateTime.Now, DateTime.Now));
        }

        public DbSet<ThreadDto> Threads { get; set; }
    }
}