using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GitCopy.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Text = "I know Right"},
                new Comment { Id = 2, Text = "That's funny XD"},
                new Comment { Id = 3, Text = "Is this thing even real??"}
            );
        }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Characters => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();

    }
}