    using Forum.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public static class DataSeeder
    {
        public static void SeedTopics(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = 1,
                    Title = "Literature",
                    State = State.Show,
                    Status = Status.Active,
                    CreationDate = DateTime.Now,
                    UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                },
                new Topic
                {
                    Id = 2,
                    Title = "Finance",
                    State = State.Pending,
                    Status = Status.Active,
                    CreationDate = DateTime.Now,
                    UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                },
                new Topic
                {
                    Id = 3,
                    Title = "Programming",
                    State = State.Hide,
                    Status = Status.Inactive,
                    CreationDate = DateTime.Now,
                    UserId = "382EE802-2DDC-4C96-917A-A5D6CE99E837"
                }
                );
        }

        public static void SeedComments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Content ="This is the first comment of first topic",
                    CreationDate = DateTime.Now,
                    TopicId = 1,
                    UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                },
                new Comment
                {
                    Id = 2,
                    Content = "This is the second comment of first topic",
                    CreationDate = DateTime.Now,
                    TopicId = 1,
                    UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                },
                new Comment
                {
                    Id = 3,
                    Content = "This is the third comment of first topic",
                    CreationDate = DateTime.Now,
                    TopicId = 1,
                    UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                },
                new Comment
                {
                    Id = 4,
                    Content = "This is the first comment of second topic",
                    CreationDate = DateTime.Now,
                    TopicId = 2,
                    UserId = "382EE802-2DDC-4C96-917A-A5D6CE99E837"
                },
                new Comment
                {
                    Id = 5,
                    Content = "This is the second comment of second topic",
                    CreationDate = DateTime.Now,
                    TopicId = 2,
                    UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                },
                new Comment
                {
                    Id = 6,
                    Content = "This is the third comment of second topic",
                    CreationDate = DateTime.Now,
                    TopicId = 2,
                    UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                },
                new Comment
                {
                    Id = 7,
                    Content = "This is the first comment of third topic",
                    CreationDate = DateTime.Now,
                    TopicId = 3,
                    UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                },
                new Comment
                {
                    Id = 8,
                    Content = "This is the second comment of third topic",
                    CreationDate = DateTime.Now,
                    TopicId = 3,
                    UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                },
                new Comment
                {
                    Id = 9,
                    Content = "This is the third comment of third topic",
                    CreationDate = DateTime.Now,
                    TopicId = 3,
                    UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                }
                );
        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "C9BF616B-A4D0-4033-BDE5-5DA123D4372D", Name = "Admin", NormalizedName ="ADMIN" },
                new IdentityRole { Id = "0B87FB7B-7478-4B0A-BA90-471B19D5B088", Name = "User", NormalizedName = "USER"}
            );
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            PasswordHasher<IdentityUser> hasher = new();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C",
                    Name = "Tinatin",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"),
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    Access = true
                },
                new ApplicationUser()
                {
                    Id = "31F51212-AD5F-4830-A984-C52AF4004702",
                    Name = "Niel",
                    UserName = "Gaiman@gmail.com",
                    NormalizedUserName = "GAIMAN@GMAIL.COM",
                    Email = "Gaiman@gmail.com",
                    NormalizedEmail = "GAIMAN@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "gaiman123"),
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    Access = true
                },
                new ApplicationUser()
                {
                    Id = "382EE802-2DDC-4C96-917A-A5D6CE99E837",
                    Name = "Irving",
                    UserName = "Stone@gmail.com",
                    NormalizedUserName = "STONE@GMAIL.COM",
                    Email = "Stone@gmail.com",
                    NormalizedEmail = "STONE@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "stone123"),
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    Access = true
                }
                ); 
        }

        public static void SeedUserRoles (this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "C9BF616B-A4D0-4033-BDE5-5DA123D4372D", UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C" },
                new IdentityUserRole<string> { RoleId = "0B87FB7B-7478-4B0A-BA90-471B19D5B088", UserId = "31F51212-AD5F-4830-A984-C52AF4004702" },
                new IdentityUserRole<string> { RoleId = "0B87FB7B-7478-4B0A-BA90-471B19D5B088", UserId = "382EE802-2DDC-4C96-917A-A5D6CE99E837" }
                );

        }
    }
}
