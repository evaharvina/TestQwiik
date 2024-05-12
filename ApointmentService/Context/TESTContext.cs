using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApointmentService.Context
{
    public partial class TESTContext : DbContext
    {
        public TESTContext()
        {
        }

        public TESTContext(DbContextOptions<TESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstHoliday> MstHolidays { get; set; } = null!;
        public virtual DbSet<MstMaxAppointment> MstMaxAppointments { get; set; } = null!;
        public virtual DbSet<TrxAppointment> TrxAppointments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-1V4QVAFB\\SQLEXPRESS;Initial Catalog=TEST;Trusted_Connection=True;User Id=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstHoliday>(entity =>
            {
                entity.HasKey(e => e.HolidayId);

                entity.ToTable("MST_HOLIDAY");

                entity.Property(e => e.HolidayId).HasColumnName("holiday_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.HolidayDate)
                    .HasColumnType("date")
                    .HasColumnName("holiday_date");

                entity.Property(e => e.HolidayName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("holiday_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");
            });

            modelBuilder.Entity<MstMaxAppointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentMaxId);

                entity.ToTable("MST_MAX_APPOINTMENT");

                entity.Property(e => e.AppointmentMaxId).HasColumnName("appointment_max_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.MaxNumber).HasColumnName("max_number");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");
            });

            modelBuilder.Entity<TrxAppointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);

                entity.ToTable("TRX_APPOINTMENT");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("customer_id");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
