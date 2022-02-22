using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBaseAccessLibrary.FamousQuoteQuizDB.Models
{
    public partial class DataBaseContext : DbContext
    {
        public IQueryable<User> dbUserList;

        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<QuizType> QuizType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataBaseConfigurator.ConnectionString);
               //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               //optionsBuilder.UseSqlServer("Server=localhost;Database=FamousQuoteQuizDB;User Id=sa;Password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.QuizId).HasColumnName("Quiz_Id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Quiz)
                    .WithMany()
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Quiz");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.AnswerId).HasColumnName("Answer_Id");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuizId).HasColumnName("Quiz_Id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_Client");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_Quiz");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuizTypeId).HasColumnName("QuizType_Id");

                entity.Property(e => e.RightAnswerId).HasColumnName("RightAnswer_Id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.QuizType)
                    .WithMany(p => p.Quiz)
                    .HasForeignKey(d => d.QuizTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_QuizType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quiz)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_User");
            });

            modelBuilder.Entity<QuizType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
