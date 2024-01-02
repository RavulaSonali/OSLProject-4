using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppAPI.Models
{
    public partial class Rainbowschool4DbContext : DbContext
    {
        public Rainbowschool4DbContext()
        {
        }

        public Rainbowschool4DbContext(DbContextOptions<Rainbowschool4DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-ICOPGDO\\MSSQLSERVER01; database=Rainbowschool4Db; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mark>(entity =>
            {
                entity.Property(e => e.MarkId).ValueGeneratedNever();

                entity.Property(e => e.Mark1).HasColumnName("Mark");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_SubjectID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubjectID");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
