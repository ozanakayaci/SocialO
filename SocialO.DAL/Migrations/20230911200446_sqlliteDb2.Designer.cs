﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialO.DAL.DBContexts;

#nullable disable

namespace SocialO.DAL.Migrations
{
    [DbContext(typeof(SqlDBContext))]
    [Migration("20230911200446_sqlliteDb2")]
    partial class sqlliteDb2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("SocialO.Entities.Concrete.FollowerRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateFollowed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 11, 23, 4, 46, 464, DateTimeKind.Local).AddTicks(7150));

                    b.Property<int?>("FollowerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("FollowerRelationships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateFollowed = new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1846),
                            FollowerId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateFollowed = new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1854),
                            FollowerId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            DateFollowed = new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1855),
                            FollowerId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateFollowed = new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1857),
                            FollowerId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatePosted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(8439));

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.PostComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCommented")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(5525));

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostComments");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.PostFavorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateFavorited")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(4082));

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostFavorites");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Active");

                    b.Property<DateTime>("DataRegistered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(7280));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("User");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountStatus = "Active",
                            DataRegistered = new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3224),
                            Email = "admin@socialo.com",
                            Password = "admin",
                            UserType = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccountStatus = "Active",
                            DataRegistered = new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3233),
                            Email = "user1@socialo.com",
                            Password = "user1",
                            UserType = "User",
                            Username = "user1"
                        },
                        new
                        {
                            Id = 3,
                            AccountStatus = "Active",
                            DataRegistered = new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3235),
                            Email = "user2@socialo.com",
                            Password = "user2",
                            UserType = "User",
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(7929));

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<char?>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.FollowerRelationship", b =>
                {
                    b.HasOne("SocialO.Entities.Concrete.User", "Follower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialO.Entities.Concrete.User", "User")
                        .WithMany("Following")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Follower");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.Post", b =>
                {
                    b.HasOne("SocialO.Entities.Concrete.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.PostComment", b =>
                {
                    b.HasOne("SocialO.Entities.Concrete.Post", "Post")
                        .WithMany("PostComments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialO.Entities.Concrete.User", "User")
                        .WithMany("PostComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.PostFavorite", b =>
                {
                    b.HasOne("SocialO.Entities.Concrete.Post", "Post")
                        .WithMany("PostFavorites")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialO.Entities.Concrete.User", "User")
                        .WithMany("PostFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.UserProfile", b =>
                {
                    b.HasOne("SocialO.Entities.Concrete.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("SocialO.Entities.Concrete.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.Post", b =>
                {
                    b.Navigation("PostComments");

                    b.Navigation("PostFavorites");
                });

            modelBuilder.Entity("SocialO.Entities.Concrete.User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("PostComments");

                    b.Navigation("PostFavorites");

                    b.Navigation("Posts");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
