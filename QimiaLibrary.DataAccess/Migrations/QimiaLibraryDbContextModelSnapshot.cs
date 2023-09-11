﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QimiaLibrary.DataAccess;

#nullable disable

namespace QimiaLibrary.DataAccess.Migrations
{
    [DbContext(typeof(QimiaLibraryDbContext))]
    partial class QimiaLibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.BookStatus", b =>
                {
                    b.Property<int>("BStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BStatusID"));

                    b.Property<string>("BStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BStatusID");

                    b.ToTable("BookStatus");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Books", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BStatusID")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("BStatusID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.ReservationStatus", b =>
                {
                    b.Property<int>("RStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RStatusID"));

                    b.Property<string>("RStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RStatusID");

                    b.ToTable("ReservationStatus");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Reservations", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int?>("BooksBookID")
                        .HasColumnType("int");

                    b.Property<int>("RStatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerID")
                        .HasColumnType("int");

                    b.Property<int?>("WorkersWorkerID")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("BookID");

                    b.HasIndex("BooksBookID");

                    b.HasIndex("RStatusID");

                    b.HasIndex("WorkerID");

                    b.HasIndex("WorkersWorkerID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.WorkerStatus", b =>
                {
                    b.Property<int>("WStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WStatusID"));

                    b.Property<string>("WStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WStatusID");

                    b.ToTable("WorkerStatus");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Workers", b =>
                {
                    b.Property<int>("WorkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerID"));

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WStatusID")
                        .HasColumnType("int");

                    b.HasKey("WorkerID");

                    b.HasIndex("WStatusID");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Books", b =>
                {
                    b.HasOne("QimiaLibrary.DataAccess.Entities.BookStatus", "BookStatus")
                        .WithMany()
                        .HasForeignKey("BStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookStatus");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Reservations", b =>
                {
                    b.HasOne("QimiaLibrary.DataAccess.Entities.Books", "Books")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QimiaLibrary.DataAccess.Entities.Books", null)
                        .WithMany("Reservations")
                        .HasForeignKey("BooksBookID");

                    b.HasOne("QimiaLibrary.DataAccess.Entities.ReservationStatus", "ReservationStatus")
                        .WithMany()
                        .HasForeignKey("RStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QimiaLibrary.DataAccess.Entities.Workers", "Workers")
                        .WithMany()
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QimiaLibrary.DataAccess.Entities.Workers", null)
                        .WithMany("Reservations")
                        .HasForeignKey("WorkersWorkerID");

                    b.Navigation("Books");

                    b.Navigation("ReservationStatus");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Workers", b =>
                {
                    b.HasOne("QimiaLibrary.DataAccess.Entities.WorkerStatus", "WorkerStatus")
                        .WithMany()
                        .HasForeignKey("WStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkerStatus");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Books", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Workers", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
