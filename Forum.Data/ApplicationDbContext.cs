using Forum.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Topic)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.TopicId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ApplicationUser)
                .WithMany (c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                

            modelBuilder.SeedRoles();
            modelBuilder.SeedUsers();
            modelBuilder.SeedUserRoles();
            modelBuilder.SeedTopics();
            modelBuilder.SeedComments();
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<ApplicationUser> Users {  get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
