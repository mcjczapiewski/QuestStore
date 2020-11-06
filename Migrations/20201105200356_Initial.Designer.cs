﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestStore.Models;

namespace QuestStore.Migrations
{
    [DbContext(typeof(horizonp_questcredentialsContext))]
    [Migration("20201105200356_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuestStore.Models.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("QuestStore.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(128)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Value")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int(11)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("QuestStore.Models.EfmigrationsHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasColumnType("varchar(95)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__EFMigrationsHistory");
                });

            modelBuilder.Entity("QuestStore.Models.Groups", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("''")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<int>("NumberOfPpl")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int(11)");

                    b.HasKey("GroupId")
                        .HasName("PRIMARY");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("QuestStore.Models.GroupsQuests", b =>
                {
                    b.Property<int>("GroupdQuestsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int(11)");

                    b.Property<int>("QuestId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("enum('In progress','Completed','Rewarded')")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("GroupdQuestsId")
                        .HasName("PRIMARY");

                    b.HasIndex("GroupId")
                        .HasName("groupId");

                    b.HasIndex("QuestId")
                        .HasName("questId1");

                    b.ToTable("GroupsQuests");
                });

            modelBuilder.Entity("QuestStore.Models.Items", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Category")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<bool>("Extra")
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("ItemId")
                        .HasName("PRIMARY");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("Name");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("QuestStore.Models.Quests", b =>
                {
                    b.Property<int>("QuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<bool?>("Extra")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<int>("Reward")
                        .HasColumnType("int(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("QuestId")
                        .HasName("PRIMARY");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasName("Title");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("QuestStore.Models.Store", b =>
                {
                    b.Property<int>("StoreItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("NumberAvailable")
                        .HasColumnType("int(2)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("StoreItemId")
                        .HasName("PRIMARY");

                    b.HasIndex("ItemId")
                        .IsUnique()
                        .HasName("ItemId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("QuestStore.Models.Technologies", b =>
                {
                    b.Property<int>("TechId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("''")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("TechId")
                        .HasName("PRIMARY");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("Name");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("QuestStore.Models.UserInventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int(11)");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("InventoryId")
                        .HasName("PRIMARY");

                    b.HasIndex("ItemId")
                        .HasName("item_ID");

                    b.HasIndex("UserId")
                        .HasName("user_ID");

                    b.ToTable("UserInventory");
                });

            modelBuilder.Entity("QuestStore.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasColumnType("int(10)");

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(3)");

                    b.Property<string>("CredentialsId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("enum('male','female','NK')")
                        .HasDefaultValueSql("'NK'")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(8)")
                        .HasDefaultValueSql("'1'");

                    b.Property<bool?>("Mentor")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("0")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex("CredentialsId")
                        .HasName("FK_Users_AspNetUsers");

                    b.HasIndex("GroupId")
                        .HasName("Users_FK");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuestStore.Models.UsersQuests", b =>
                {
                    b.Property<int>("UsersQuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("QuestId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("enum('In progress','Completed','Rewarded')")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_polish_ci");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("UsersQuestId")
                        .HasName("PRIMARY");

                    b.HasIndex("QuestId")
                        .HasName("questId");

                    b.HasIndex("UserId")
                        .HasName("userId");

                    b.ToTable("UsersQuests");
                });

            modelBuilder.Entity("QuestStore.Models.UsersTech", b =>
                {
                    b.Property<int>("UsersTechId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("TechId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("UsersTechId");

                    b.HasIndex("TechId")
                        .HasName("techID");

                    b.HasIndex("UserId")
                        .HasName("user-ID");

                    b.ToTable("UsersTech");
                });

            modelBuilder.Entity("QuestStore.Models.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<double?>("Balance")
                        .HasColumnType("double(10,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int(10)");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasName("UserId");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("QuestStore.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("QuestStore.Models.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("QuestStore.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("QuestStore.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("QuestStore.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestStore.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.AspNetUserTokens", b =>
                {
                    b.HasOne("QuestStore.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.GroupsQuests", b =>
                {
                    b.HasOne("QuestStore.Models.Groups", "Group")
                        .WithMany("GroupsQuests")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("groupId")
                        .IsRequired();

                    b.HasOne("QuestStore.Models.Quests", "Quest")
                        .WithMany("GroupsQuests")
                        .HasForeignKey("QuestId")
                        .HasConstraintName("questId1")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.Store", b =>
                {
                    b.HasOne("QuestStore.Models.Items", "Item")
                        .WithOne("Store")
                        .HasForeignKey("QuestStore.Models.Store", "ItemId")
                        .HasConstraintName("itemInStore");
                });

            modelBuilder.Entity("QuestStore.Models.UserInventory", b =>
                {
                    b.HasOne("QuestStore.Models.Items", "Item")
                        .WithMany("UserInventory")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("item_ID")
                        .IsRequired();

                    b.HasOne("QuestStore.Models.Users", "User")
                        .WithMany("UserInventory")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_ID")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.Users", b =>
                {
                    b.HasOne("QuestStore.Models.AspNetUsers", "Credentials")
                        .WithMany("Users")
                        .HasForeignKey("CredentialsId")
                        .HasConstraintName("FK_Users_AspNetUsers")
                        .IsRequired();

                    b.HasOne("QuestStore.Models.Groups", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("Users_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.UsersQuests", b =>
                {
                    b.HasOne("QuestStore.Models.Quests", "Quest")
                        .WithMany("UsersQuests")
                        .HasForeignKey("QuestId")
                        .HasConstraintName("questId")
                        .IsRequired();

                    b.HasOne("QuestStore.Models.Users", "User")
                        .WithMany("UsersQuests")
                        .HasForeignKey("UserId")
                        .HasConstraintName("userId")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestStore.Models.UsersTech", b =>
                {
                    b.HasOne("QuestStore.Models.Technologies", "Tech")
                        .WithMany("UsersTech")
                        .HasForeignKey("TechId")
                        .HasConstraintName("techID");

                    b.HasOne("QuestStore.Models.Users", "User")
                        .WithMany("UsersTech")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user-ID");
                });

            modelBuilder.Entity("QuestStore.Models.Wallet", b =>
                {
                    b.HasOne("QuestStore.Models.Users", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("QuestStore.Models.Wallet", "UserId")
                        .HasConstraintName("user_wallet")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}