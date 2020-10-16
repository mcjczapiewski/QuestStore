using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuestStore.Models
{
    public partial class horizonp_ccqueststoreContext : DbContext
    {
        public horizonp_ccqueststoreContext()
        {
        }

        public horizonp_ccqueststoreContext(DbContextOptions<horizonp_ccqueststoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<GroupsQuests> GroupsQuests { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Quests> Quests { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Technologies> Technologies { get; set; }
        public virtual DbSet<UserInventory> UserInventory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersQuests> UsersQuests { get; set; }
        public virtual DbSet<UsersTech> UsersTech { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=91.192.164.15;uid=horizonp_grant;pwd=12345;database=horizonp_cc-queststore", x => x.ServerVersion("10.3.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Name)
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.GroupId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NumberOfPpl).HasColumnType("int(11)");
            });

            modelBuilder.Entity<GroupsQuests>(entity =>
            {
                entity.HasKey(e => e.GroupdQuestsId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.GroupId)
                    .HasName("groupId");

                entity.HasIndex(e => e.QuestId)
                    .HasName("questId1");

                entity.Property(e => e.GroupdQuestsId).HasColumnType("int(11)");

                entity.Property(e => e.GroupId).HasColumnType("int(11)");

                entity.Property(e => e.QuestId).HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('In progress','Completed','Rewarded')")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupsQuests)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("groupId");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.GroupsQuests)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("questId1");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Name)
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnType("enum('Y','N')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Quests>(entity =>
            {
                entity.HasKey(e => e.QuestId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Title)
                    .HasName("Title")
                    .IsUnique();

                entity.Property(e => e.QuestId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnType("enum('Y','N')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Reward).HasColumnType("double(10,2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreItemId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ItemId)
                    .HasName("ItemId")
                    .IsUnique();

                entity.Property(e => e.StoreItemId).HasColumnType("int(11)");

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.NumberAvailable).HasColumnType("int(2)");

                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Item)
                    .WithOne(p => p.Store)
                    .HasForeignKey<Store>(d => d.ItemId)
                    .HasConstraintName("itemInStore");
            });

            modelBuilder.Entity<Technologies>(entity =>
            {
                entity.HasKey(e => e.TechId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Name)
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.TechId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<UserInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ItemId)
                    .HasName("item_ID");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_ID");

                entity.Property(e => e.InventoryId).HasColumnType("int(11)");

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasColumnType("enum('Y','N')")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.UserInventory)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInventory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CredentialsId)
                    .HasName("CredentialsId")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("Email")
                    .IsUnique();

                entity.HasIndex(e => e.GroupId)
                    .HasName("Users_FK");

                entity.HasIndex(e => e.Login)
                    .HasName("Login")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Age).HasColumnType("int(3)");

                entity.Property(e => e.CredentialsId).HasColumnType("varchar(255)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("enum('male','female')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GroupId).HasColumnType("int(8)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mentor)
                    .IsRequired()
                    .HasColumnType("enum('Y','N')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("Users_FK");
            });

            modelBuilder.Entity<UsersQuests>(entity =>
            {
                entity.HasKey(e => e.UsersQuestId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.QuestId)
                    .HasName("questId");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.UsersQuestId).HasColumnType("int(11)");

                entity.Property(e => e.QuestId).HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('In progress','Completed','Rewarded')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.UsersQuests)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("questId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersQuests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userId");
            });

            modelBuilder.Entity<UsersTech>(entity =>
            {
                entity.HasIndex(e => e.TechId)
                    .HasName("techID");

                entity.HasIndex(e => e.UserId)
                    .HasName("user-ID");

                entity.Property(e => e.UsersTechId).HasColumnType("int(11)");

                entity.Property(e => e.TechId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Tech)
                    .WithMany(p => p.UsersTech)
                    .HasForeignKey(d => d.TechId)
                    .HasConstraintName("techID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersTech)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user-ID");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UserId")
                    .IsUnique();

                entity.Property(e => e.WalletId).HasColumnType("int(10)");

                entity.Property(e => e.Balance).HasColumnType("double(10,2)");

                entity.Property(e => e.UserId).HasColumnType("int(10)");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Wallet)
                    .HasForeignKey<Wallet>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_wallet");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
