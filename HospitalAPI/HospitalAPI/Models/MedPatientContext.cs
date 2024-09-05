using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Models;

public partial class MedPatientContext : DbContext
{
    //public MedPatientContext()
    //{
    //}

    public MedPatientContext(DbContextOptions<MedPatientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = MedPatient; Integrated Security = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.ToTable("Cabinet");

            entity.Property(e => e.CabinetNum).HasMaxLength(10);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorLastName).HasMaxLength(50);
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.DoctorSurname).HasMaxLength(50);

            entity.HasOne(d => d.CabinetNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Cabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Cabinet");

            entity.HasOne(d => d.SectorNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Sector)
                .HasConstraintName("FK_Doctor_Sector");

            entity.HasOne(d => d.SpecializationNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Specialization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Specialization");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.GenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.PatientLastName).HasMaxLength(50);
            entity.Property(e => e.PatientName).HasMaxLength(50);
            entity.Property(e => e.PatientSurName).HasMaxLength(50);

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_Gender");

            entity.HasOne(d => d.SectorNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Sector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_Sector");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.ToTable("Sector");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.ToTable("Specialization");

            entity.Property(e => e.SpecializationName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
