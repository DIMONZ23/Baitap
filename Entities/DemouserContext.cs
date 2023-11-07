using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Baitap.Entities;

public partial class DemouserContext : DbContext
{
    public DemouserContext()
    {
    }

    public DemouserContext(DbContextOptions<DemouserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acc> Accs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=demouser;Username=postgres;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("acc");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .HasColumnName("mobile");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
