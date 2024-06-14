﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Forum.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Access")
                        .HasColumnType("bit");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C",
                            Access = true,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6631155d-8730-4fcf-aefa-60e4dbf32332",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Tinatin",
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEHeVmTq9tvbfGFuWQpIsXxySFZRL6k/I3umrWmwLO1fGO930e73wpBtUaFk46LRAjA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f7e6c72f-7f29-4d69-b755-93ac43113df1",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "31F51212-AD5F-4830-A984-C52AF4004702",
                            Access = true,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "64fb391c-7f2d-4012-a39a-291df3ab81dc",
                            Email = "Gaiman@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Niel",
                            NormalizedEmail = "GAIMAN@GMAIL.COM",
                            NormalizedUserName = "GAIMAN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAECO0310IkyTAiuVB23Ui0YTINj5yf0jqKWyKMODZ0Hul9VKvAn1qhliS4+zC5R9eBw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dad9e798-365b-4637-95bd-5a53c23151a6",
                            TwoFactorEnabled = false,
                            UserName = "Gaiman@gmail.com"
                        },
                        new
                        {
                            Id = "382EE802-2DDC-4C96-917A-A5D6CE99E837",
                            Access = true,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2314b0e5-e73f-4017-929a-805437220de4",
                            Email = "Stone@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Irving",
                            NormalizedEmail = "STONE@GMAIL.COM",
                            NormalizedUserName = "STONE@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJWniS2rNH5XLiyg2QAYJv+4cn0sPzgvPk6TbutSi+IjwMH+pBOjKh/+2zvOM7Pgcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "147e41da-d37e-4334-9f5d-17706bbc90dd",
                            TwoFactorEnabled = false,
                            UserName = "Stone@gmail.com"
                        });
                });

            modelBuilder.Entity("Forum.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is the first comment of first topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4516),
                            TopicId = 1,
                            UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is the second comment of first topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4519),
                            TopicId = 1,
                            UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                        },
                        new
                        {
                            Id = 3,
                            Content = "This is the third comment of first topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4521),
                            TopicId = 1,
                            UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                        },
                        new
                        {
                            Id = 4,
                            Content = "This is the first comment of second topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4522),
                            TopicId = 2,
                            UserId = "382EE802-2DDC-4C96-917A-A5D6CE99E837"
                        },
                        new
                        {
                            Id = 5,
                            Content = "This is the second comment of second topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4533),
                            TopicId = 2,
                            UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                        },
                        new
                        {
                            Id = 6,
                            Content = "This is the third comment of second topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4535),
                            TopicId = 2,
                            UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                        },
                        new
                        {
                            Id = 7,
                            Content = "This is the first comment of third topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4536),
                            TopicId = 3,
                            UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                        },
                        new
                        {
                            Id = 8,
                            Content = "This is the second comment of third topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4538),
                            TopicId = 3,
                            UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                        },
                        new
                        {
                            Id = 9,
                            Content = "This is the third comment of third topic",
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4540),
                            TopicId = 3,
                            UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                        });
                });

            modelBuilder.Entity("Forum.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4292),
                            State = 2,
                            Status = 1,
                            Title = "Literature",
                            UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4296),
                            State = 1,
                            Status = 1,
                            Title = "Finance",
                            UserId = "31F51212-AD5F-4830-A984-C52AF4004702"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2024, 6, 14, 10, 18, 6, 87, DateTimeKind.Local).AddTicks(4298),
                            State = 3,
                            Status = 2,
                            Title = "Programming",
                            UserId = "382EE802-2DDC-4C96-917A-A5D6CE99E837"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "C9BF616B-A4D0-4033-BDE5-5DA123D4372D",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "0B87FB7B-7478-4B0A-BA90-471B19D5B088",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "4F17ABDF-4A9C-4F0D-9EBC-36B847686A3C",
                            RoleId = "C9BF616B-A4D0-4033-BDE5-5DA123D4372D"
                        },
                        new
                        {
                            UserId = "31F51212-AD5F-4830-A984-C52AF4004702",
                            RoleId = "0B87FB7B-7478-4B0A-BA90-471B19D5B088"
                        },
                        new
                        {
                            UserId = "382EE802-2DDC-4C96-917A-A5D6CE99E837",
                            RoleId = "0B87FB7B-7478-4B0A-BA90-471B19D5B088"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Forum.Entities.Comment", b =>
                {
                    b.HasOne("Forum.Entities.Topic", "Topic")
                        .WithMany("Comments")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Forum.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Forum.Entities.Topic", b =>
                {
                    b.HasOne("Forum.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Topics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Forum.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Forum.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Forum.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forum.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Forum.Entities.Topic", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
