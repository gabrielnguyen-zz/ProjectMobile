using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectMobile.Models
{
    public partial class ProjectMobileContext : DbContext
    {
        public ProjectMobileContext()
        {
        }

        public ProjectMobileContext(DbContextOptions<ProjectMobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Scene> Scene { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }

        // Unable to generate entity type for table 'dbo.SceneActor'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SceneTool'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-54D0I6M;Database=ProjectMobile;uid=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId)
                    .HasColumnName("accountID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.ActorId).HasColumnName("actorID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActorDes)
                    .HasColumnName("actorDes")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ActorName)
                    .HasColumnName("actorName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("createdTime")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updatedTime")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Scene>(entity =>
            {
                entity.Property(e => e.SceneId).HasColumnName("sceneID");

                entity.Property(e => e.SceneActors)
                    .HasColumnName("sceneActors")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SceneDes)
                    .HasColumnName("sceneDes")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SceneLoc)
                    .HasColumnName("sceneLoc")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SceneName)
                    .HasColumnName("sceneName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SceneRec).HasColumnName("sceneRec");

                entity.Property(e => e.SceneTimeStart)
                    .HasColumnName("sceneTimeStart")
                    .HasColumnType("date");

                entity.Property(e => e.SceneTimeStop)
                    .HasColumnName("sceneTimeStop")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.Property(e => e.ToolId)
                    .HasColumnName("toolID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("createdTime")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.ToolDes)
                    .HasColumnName("toolDes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToolName)
                    .HasColumnName("toolName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updatedTime")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}
