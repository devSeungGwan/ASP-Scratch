﻿// <auto-generated />
using ASPnetNote.MVC6.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASPnetNote.MVC6.Migrations
{
    [DbContext(typeof(ASPnetNoteDbContext))]
    partial class ASPnetNoteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ASPnetNote.MVC6.Models.Note", b =>
                {
                    b.Property<int>("NoteNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NoteContents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoteTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserNo")
                        .HasColumnType("int");

                    b.HasKey("NoteNo");

                    b.HasIndex("UserNo");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("ASPnetNote.MVC6.Models.User", b =>
                {
                    b.Property<int>("UserNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserNo");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASPnetNote.MVC6.Models.Note", b =>
                {
                    b.HasOne("ASPnetNote.MVC6.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
