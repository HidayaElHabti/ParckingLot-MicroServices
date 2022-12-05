using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UpdateCard.Data;

public partial class CardDbContext : DbContext
{
    public CardDbContext()
    {
    }

    public CardDbContext(DbContextOptions<CardDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Database = CardDB; Integrated Security = True; Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.Property(e => e.CarBrand).HasColumnName("carBrand");
            entity.Property(e => e.CarModel).HasColumnName("carModel");
            entity.Property(e => e.CarNumber).HasColumnName("carNumber");
            entity.Property(e => e.LastEntered).HasColumnName("lastEntered");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
