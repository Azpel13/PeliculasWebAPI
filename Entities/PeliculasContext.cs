using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PMovie.DAL.Entities;

namespace PMovie.DAL
{
    public partial class PeliculasContext : DbContext
    {
        public PeliculasContext()
        {
        }

        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PRIMARY");

                entity.ToTable("genero");

                entity.Property(e => e.IdGenero).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula)
                    .HasName("PRIMARY");

                entity.ToTable("pelicula");

                entity.HasIndex(e => e.IdGenero)
                    .HasName("fk_Pelicula_Genero_idx");

                entity.Property(e => e.IdPelicula).HasColumnType("int(11)");

                entity.Property(e => e.DuracionMinutos).HasColumnType("int(11)");

                entity.Property(e => e.FechaEstreno).HasColumnType("date");

                entity.Property(e => e.IdGenero).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Pelicula)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pelicula_Genero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
