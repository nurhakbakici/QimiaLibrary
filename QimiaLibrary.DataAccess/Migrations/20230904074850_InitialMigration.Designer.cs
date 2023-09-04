﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QimiaLibrary.DataAccess;

#nullable disable

namespace QimiaLibrary.DataAccess.Migrations
{
    [DbContext(typeof(QimiaLibraryDbContext))]
    [Migration("20230904074850_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("int");

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

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Reservations", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("BookID")
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

                    b.HasOne("QimiaLibrary.DataAccess.Entities.Reservations", "Reservations")
                        .WithOne("Books")
                        .HasForeignKey("QimiaLibrary.DataAccess.Entities.Books", "BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookStatus");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Reservations", b =>
                {
                    b.HasOne("QimiaLibrary.DataAccess.Entities.Workers", "Workers")
                        .WithMany()
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QimiaLibrary.DataAccess.Entities.Workers", null)
                        .WithMany("Reservations")
                        .HasForeignKey("WorkersWorkerID");

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

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Reservations", b =>
                {
                    b.Navigation("Books")
                        .IsRequired();
                });

            modelBuilder.Entity("QimiaLibrary.DataAccess.Entities.Workers", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
