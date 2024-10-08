using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Turnos.Data.Entidades;

namespace Veterinaria.Turnos.Data.Data;

public partial class VeterinariaDbContext : DbContext
{
    public VeterinariaDbContext()
    {
    }

    public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Especie> Especies { get; set; }

    public virtual DbSet<EstadoTurno> EstadosTurno { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoServicio> TiposServicio { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Veterinario> Veterinarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Veterinaria;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasOne(d => d.Cliente).WithMany(p => p.Mascotas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mascotas_Clientes");

            entity.HasOne(d => d.Especie).WithMany(p => p.Mascotas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mascotas_Especies");

            entity.HasOne(d => d.Raza).WithMany(p => p.Mascotas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mascotas_Razas");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasOne(d => d.Especie).WithMany(p => p.Razas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Razas_Especies");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasOne(d => d.TipoServicio).WithMany(p => p.Servicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicio_TiposServicio");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasOne(d => d.EstadoTurno).WithMany(p => p.Turnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turnos_EstadosTurno");

            entity.HasOne(d => d.Mascota).WithMany(p => p.Turnos).HasConstraintName("FK_Turnos_Mascotas");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Turnos).HasConstraintName("FK_Turnos_Servicio");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Turnos).HasConstraintName("FK_Turnos_Veterinarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
