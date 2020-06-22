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
        public virtual DbSet<SceneActor> SceneActor { get; set; }
        public virtual DbSet<SceneTool> SceneTool { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=pnlreporter.database.windows.net;Database=ProjectMobile;uid=swdpnl;password=PhucDepTrai2020");
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

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Actor)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Actor_Account");
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

            modelBuilder.Entity<SceneActor>(entity =>
            {
                entity.HasKey(e => new { e.SceneId, e.ActorId });

                entity.Property(e => e.SceneId).HasColumnName("sceneID");

                entity.Property(e => e.ActorId).HasColumnName("actorID");

                entity.Property(e => e.ActFrom)
                    .IsRequired()
                    .HasColumnName("actFrom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActTo)
                    .IsRequired()
                    .HasColumnName("actTo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.SceneActor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SceneActor_Actor");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.SceneActor)
                    .HasForeignKey(d => d.SceneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SceneActor_Scene");
            });

            modelBuilder.Entity<SceneTool>(entity =>
            {
                entity.HasKey(e => new { e.SceneId, e.ToolId });

                entity.Property(e => e.SceneId).HasColumnName("sceneID");

                entity.Property(e => e.ToolId).HasColumnName("toolID");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasMaxLength(10);

                entity.Property(e => e.ToolFrom)
                    .HasColumnName("toolFrom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToolTo)
                    .HasColumnName("toolTo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.SceneTool)
                    .HasForeignKey(d => d.SceneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SceneTool_Scene");

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.SceneTool)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SceneTool_Tool");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.Property(e => e.ToolId).HasColumnName("toolID");

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
