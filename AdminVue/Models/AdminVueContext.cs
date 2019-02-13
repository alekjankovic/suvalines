using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminVue.Models
{
    public partial class AdminVueContext : DbContext
    {
        public AdminVueContext()
        {
        }

        public AdminVueContext(DbContextOptions<AdminVueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Profiles> Profiles { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ImgUrl).IsUnicode(false);

                entity.Property(e => e.LongTitle)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ArticlesGroup)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("Articles_GroupId_FK");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ArticlesStatus)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("Articles_StatusId_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Articles_Users");

                entity.HasOne(d => d.Visible)
                    .WithMany(p => p.ArticlesVisible)
                    .HasForeignKey(d => d.VisibleId)
                    .HasConstraintName("Articles_VisibleId_FK");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comments_Articles");
            });

            modelBuilder.Entity<Profiles>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Profiles__1788CC4D22AA2996")
                    .IsUnique();

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Street).HasMaxLength(30);

                entity.Property(e => e.Surname).HasMaxLength(15);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Profiles)
                    .HasForeignKey<Profiles>(d => d.UserId)
                    .HasConstraintName("Profiles_UserId_FK");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Desccription).HasMaxLength(30);

                entity.Property(e => e.LongName).HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Pass).HasMaxLength(15);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UsersStatus)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("Users_StatusId_FK");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.UsersType)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Users_TypeId_FK");
            });
        }
    }
}
