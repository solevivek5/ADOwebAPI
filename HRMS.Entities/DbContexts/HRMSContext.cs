using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HRMS.Entities.Models;

namespace HRMS.Entities.DbContexts
{
    public partial class HRMSContext : DbContext
    {
        public HRMSContext()
        {
        }

        public HRMSContext(DbContextOptions<HRMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Hr> Hrs { get; set; } = null!;
        public virtual DbSet<TblTerm> TblTerms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Name=DbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("department_name");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("salary");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sex")
                    .IsFixedLength();

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<Hr>(entity =>
            {
                entity.ToTable("HR");

                entity.Property(e => e.HrId).HasColumnName("hr_id");

                entity.Property(e => e.Company)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(150)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(150)
                    .HasColumnName("password_salt");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblTerm>(entity =>
            {
                entity.HasKey(e => e.STermCode);

                entity.ToTable("tblTerm");

                entity.Property(e => e.STermCode)
                    .HasMaxLength(10)
                    .HasColumnName("sTermCode");

                entity.Property(e => e.BActiveStatus).HasColumnName("bActiveStatus");

                entity.Property(e => e.DtUpdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("dtUpdatedon");

                entity.Property(e => e.STermName)
                    .HasMaxLength(100)
                    .HasColumnName("sTermName");

                entity.Property(e => e.SUpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("sUpdatedBy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
