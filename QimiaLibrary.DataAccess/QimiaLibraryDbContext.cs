using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess;

public class QimiaLibraryDbContext : DbContext
{
    public QimiaLibraryDbContext(DbContextOptions<QimiaLibraryDbContext> contextOptions) : base(contextOptions)
    {

    }

    public DbSet<Workers> Workers { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Reservations> Reservations { get; set; }
    public DbSet<WorkerStatus> WorkerStatus { get; set; }
    public DbSet<BookStatus> BookStatus { get; set; }
    public DbSet<ReservationStatus> ReservationStatus { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Workers>()
            .HasOne(w => w.WorkerStatus)
            .WithMany()
            .HasForeignKey(w => w.WStatusID);

        modelBuilder.Entity<Books>()
            .HasOne(b => b.BookStatus)
            .WithMany()
            .HasForeignKey(b => b.BStatusID);

        modelBuilder.Entity<Reservations>()
            .HasOne(r => r.ReservationStatus)
            .WithMany()
            .HasForeignKey(r => r.RStatusID);

        modelBuilder.Entity<Reservations>().
            HasOne(r => r.Workers)
            .WithMany()
            .HasForeignKey(r => r.WorkerID);

        modelBuilder.Entity<Reservations>().
            HasOne(r => r.Books)
            .WithMany()
            .HasForeignKey(r => r.BookID);

        //modelBuilder.Entity<Reservations>()
        //      .HasOne(r => r.Books)
        //      .WithOne(b => b.Reservations)
        //      .HasForeignKey<Books>(b => b.BookID);

        modelBuilder.Entity<Reservations>().
            HasOne(r => r.Books)
            .WithMany()
            .HasForeignKey(r => r.BookID);

        modelBuilder.Entity<BookStatus>()
            .HasKey(bs => bs.BStatusID);

        modelBuilder.Entity<WorkerStatus>()
            .HasKey(ws => ws.WStatusID);

        modelBuilder.Entity<ReservationStatus>()
            .HasKey(rs => rs.RStatusID);

        modelBuilder.Entity<Books>()
            .HasKey(b => b.BookID);

        modelBuilder.Entity<Workers>()
            .HasKey(w => w.WorkerID);

        modelBuilder.Entity<Reservations>()
            .HasKey(r => r.ReservationID);
    }
}
