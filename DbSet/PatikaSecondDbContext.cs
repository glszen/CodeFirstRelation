using CodeFirstRelation.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstRelation.DbSet
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(P => P.User) //Each post belongs to a user
                .WithMany(u => u.Posts) //A user can have multiple posts
                .HasForeignKey(p => p.UserId); //UserId determines which user the post belongs to
        }

        public PatikaSecondDbContext(DbContextOptions<PatikaSecondDbContext> options)
       : base(options)
        {
        }

    }
}
