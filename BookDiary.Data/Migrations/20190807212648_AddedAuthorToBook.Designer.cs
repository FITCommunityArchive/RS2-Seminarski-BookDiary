﻿// <auto-generated />
using System;
using BookDiary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookDiary.Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20190807212648_AddedAuthorToBook")]
    partial class AddedAuthorToBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookDiary.Core.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<int>("AuthorId");

                    b.Property<byte[]>("CoverImage");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("GenreId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PagesInTotal");

                    b.Property<int>("YearPublished");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("QuoteText")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.ReadingActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("PagesRead");

                    b.Property<int>("UserBookId");

                    b.HasKey("Id");

                    b.HasIndex("UserBookId");

                    b.ToTable("ReadingActivities");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved");

                    b.Property<bool>("Archived");

                    b.Property<int>("BookId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("QuoteToRemember");

                    b.Property<int>("Rating");

                    b.Property<string>("Summary");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.UserBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<int>("BookId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("FinishedReadingOn");

                    b.Property<DateTime>("StartedReadingOn");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBooks");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Book", b =>
                {
                    b.HasOne("BookDiary.Core.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookDiary.Core.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Quote", b =>
                {
                    b.HasOne("BookDiary.Core.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BookDiary.Core.Entities.ReadingActivity", b =>
                {
                    b.HasOne("BookDiary.Core.Entities.UserBook", "UserBook")
                        .WithMany()
                        .HasForeignKey("UserBookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookDiary.Core.Entities.Review", b =>
                {
                    b.HasOne("BookDiary.Core.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookDiary.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookDiary.Core.Entities.UserBook", b =>
                {
                    b.HasOne("BookDiary.Core.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookDiary.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookDiary.Core.Entities.UserRole", b =>
                {
                    b.HasOne("BookDiary.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookDiary.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
