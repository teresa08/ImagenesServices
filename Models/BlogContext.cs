using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Imagenes.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TERESA\\SQLEXPRESS; Database=Blog; Trusted_Connection=true; Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.IdImagenes).HasName("PK__Imagenes__342B7518ACAEC686");

            entity.Property(e => e.IdImagenes).HasColumnName("idImagenes");
            entity.Property(e => e.Ruta)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
