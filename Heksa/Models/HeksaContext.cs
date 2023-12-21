using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


#nullable disable

namespace Heksa.Models
{
    public partial class HeksaContext : DbContext
    {
        public HeksaContext()
        {
        }

        public HeksaContext(DbContextOptions<HeksaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agen> Agens { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<WorkExperience> WorkExperiences { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

   
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Agen>(entity =>
            {
                entity.ToTable("Agen");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCard)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegDate).HasColumnType("date");

                entity.Property(e => e.RegStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment");

                entity.Property(e => e.AttachmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("AttachmentID");

                entity.Property(e => e.AgenId).HasColumnName("AgenID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agen)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.AgenId)
                    .HasConstraintName("FK__Attachmen__AgenI__3C69FB99");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.EducationId)
                    .ValueGeneratedNever()
                    .HasColumnName("EducationID");

                entity.Property(e => e.AgenId).HasColumnName("AgenID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Gpa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GPA");

                entity.Property(e => e.Institution)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Major)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Strala)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agen)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.AgenId)
                    .HasConstraintName("FK__Education__AgenI__3F466844");
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.ToTable("WorkExperience");

                entity.Property(e => e.WorkExperienceId)
                    .ValueGeneratedNever()
                    .HasColumnName("WorkExperienceID");

                entity.Property(e => e.AgenId).HasColumnName("AgenID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Field)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JobDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Agen)
                    .WithMany(p => p.WorkExperiences)
                    .HasForeignKey(d => d.AgenId)
                    .HasConstraintName("FK__WorkExper__AgenI__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
