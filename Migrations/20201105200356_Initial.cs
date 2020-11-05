using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "__EFMigrationsHistory",
            //    columns: table => new
            //    {
            //        MigrationId = table.Column<string>(type: "varchar(95)", nullable: false)
            //            .Annotation("MySql:CharSet", "latin1")
            //            .Annotation("MySql:Collation", "latin1_swedish_ci"),
            //        ProductVersion = table.Column<string>(type: "varchar(32)", nullable: false)
            //            .Annotation("MySql:CharSet", "latin1")
            //            .Annotation("MySql:Collation", "latin1_swedish_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.MigrationId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        Name = table.Column<string>(type: "varchar(256)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        NormalizedName = table.Column<string>(type: "varchar(256)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        NormalizedUserName = table.Column<string>(type: "varchar(256)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        Email = table.Column<string>(type: "varchar(256)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        NormalizedEmail = table.Column<string>(type: "varchar(256)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTime>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int(11)", nullable: false),
            //        UserName = table.Column<string>(type: "varchar(256)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        PasswordSalt = table.Column<byte[]>(nullable: true),
            //        PasswordHash = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Groups",
            //    columns: table => new
            //    {
            //        GroupId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(type: "varchar(50)", nullable: false, defaultValueSql: "''")
            //            .Annotation("MySql:CharSet", "latin1")
            //            .Annotation("MySql:Collation", "latin1_swedish_ci"),
            //        NumberOfPpl = table.Column<int>(type: "int(11)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.GroupId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Items",
            //    columns: table => new
            //    {
            //        ItemId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(type: "varchar(50)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci"),
            //        Category = table.Column<string>(type: "varchar(50)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci"),
            //        Extra = table.Column<bool>(type: "tinyint(1)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.ItemId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Quests",
            //    columns: table => new
            //    {
            //        QuestId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Title = table.Column<string>(type: "varchar(50)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci"),
            //        Reward = table.Column<int>(type: "int(10)", nullable: false),
            //        Description = table.Column<string>(type: "varchar(200)", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci"),
            //        Extra = table.Column<bool>(type: "tinyint(1)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.QuestId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Technologies",
            //    columns: table => new
            //    {
            //        TechId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(type: "varchar(50)", nullable: false, defaultValueSql: "''")
            //            .Annotation("MySql:CharSet", "latin1")
            //            .Annotation("MySql:Collation", "latin1_swedish_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.TechId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ClaimType = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ClaimValue = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ClaimType = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ClaimValue = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "varchar(128)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ProviderKey = table.Column<string>(type: "varchar(128)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        UserId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => new { x.LoginProvider, x.ProviderKey })
            //            .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => new { x.UserId, x.RoleId })
            //            .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        LoginProvider = table.Column<string>(type: "varchar(128)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        Name = table.Column<string>(type: "varchar(128)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci"),
            //        Value = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => new { x.UserId, x.LoginProvider, x.Name })
            //            .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserID = table.Column<int>(type: "int(10)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Gender = table.Column<string>(type: "enum('male','female','NK')", nullable: false, defaultValueSql: "'NK'")
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci"),
            //        Age = table.Column<int>(type: "int(3)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Mentor = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "0")
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_general_ci"),
            //        GroupId = table.Column<int>(type: "int(8)", nullable: false, defaultValueSql: "'1'"),
            //        CredentialsId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //            .Annotation("MySql:Collation", "utf8mb4_general_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.UserID);
            //        table.ForeignKey(
            //            name: "FK_Users_AspNetUsers",
            //            column: x => x.CredentialsId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "Users_FK",
            //            column: x => x.GroupId,
            //            principalTable: "Groups",
            //            principalColumn: "GroupId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Store",
            //    columns: table => new
            //    {
            //        StoreItemId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        ItemId = table.Column<int>(type: "int(11)", nullable: true),
            //        NumberAvailable = table.Column<int>(type: "int(2)", nullable: true),
            //        Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.StoreItemId);
            //        table.ForeignKey(
            //            name: "itemInStore",
            //            column: x => x.ItemId,
            //            principalTable: "Items",
            //            principalColumn: "ItemId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GroupsQuests",
            //    columns: table => new
            //    {
            //        GroupdQuestsId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        GroupId = table.Column<int>(type: "int(11)", nullable: false),
            //        QuestId = table.Column<int>(type: "int(11)", nullable: false),
            //        Status = table.Column<string>(type: "enum('In progress','Completed','Rewarded')", nullable: false)
            //            .Annotation("MySql:CharSet", "latin1")
            //            .Annotation("MySql:Collation", "latin1_swedish_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.GroupdQuestsId);
            //        table.ForeignKey(
            //            name: "groupId",
            //            column: x => x.GroupId,
            //            principalTable: "Groups",
            //            principalColumn: "GroupId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "questId1",
            //            column: x => x.QuestId,
            //            principalTable: "Quests",
            //            principalColumn: "QuestId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserInventory",
            //    columns: table => new
            //    {
            //        InventoryId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<int>(type: "int(11)", nullable: false),
            //        ItemId = table.Column<int>(type: "int(11)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.InventoryId);
            //        table.ForeignKey(
            //            name: "item_ID",
            //            column: x => x.ItemId,
            //            principalTable: "Items",
            //            principalColumn: "ItemId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "user_ID",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UsersQuests",
            //    columns: table => new
            //    {
            //        UsersQuestId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<int>(type: "int(11)", nullable: false),
            //        QuestId = table.Column<int>(type: "int(11)", nullable: false),
            //        Status = table.Column<string>(type: "enum('In progress','Completed','Rewarded')", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8")
            //            .Annotation("MySql:Collation", "utf8_polish_ci")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.UsersQuestId);
            //        table.ForeignKey(
            //            name: "questId",
            //            column: x => x.QuestId,
            //            principalTable: "Quests",
            //            principalColumn: "QuestId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "userId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UsersTech",
            //    columns: table => new
            //    {
            //        UsersTechId = table.Column<int>(type: "int(11)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<int>(type: "int(11)", nullable: true),
            //        TechId = table.Column<int>(type: "int(11)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UsersTech", x => x.UsersTechId);
            //        table.ForeignKey(
            //            name: "techID",
            //            column: x => x.TechId,
            //            principalTable: "Technologies",
            //            principalColumn: "TechId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "user-ID",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Wallet",
            //    columns: table => new
            //    {
            //        WalletId = table.Column<int>(type: "int(10)", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<int>(type: "int(10)", nullable: false),
            //        Balance = table.Column<double>(type: "double(10,2)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Wallet", x => x.WalletId);
            //        table.ForeignKey(
            //            name: "user_wallet",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "Name",
            //    table: "Groups",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "groupId",
            //    table: "GroupsQuests",
            //    column: "GroupId");

            //migrationBuilder.CreateIndex(
            //    name: "questId1",
            //    table: "GroupsQuests",
            //    column: "QuestId");

            //migrationBuilder.CreateIndex(
            //    name: "Name",
            //    table: "Items",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "Title",
            //    table: "Quests",
            //    column: "Title",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "ItemId",
            //    table: "Store",
            //    column: "ItemId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "Name",
            //    table: "Technologies",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "item_ID",
            //    table: "UserInventory",
            //    column: "ItemId");

            //migrationBuilder.CreateIndex(
            //    name: "user_ID",
            //    table: "UserInventory",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "FK_Users_AspNetUsers",
            //    table: "Users",
            //    column: "CredentialsId");

            //migrationBuilder.CreateIndex(
            //    name: "Users_FK",
            //    table: "Users",
            //    column: "GroupId");

            //migrationBuilder.CreateIndex(
            //    name: "questId",
            //    table: "UsersQuests",
            //    column: "QuestId");

            //migrationBuilder.CreateIndex(
            //    name: "userId",
            //    table: "UsersQuests",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "techID",
            //    table: "UsersTech",
            //    column: "TechId");

            //migrationBuilder.CreateIndex(
            //    name: "user-ID",
            //    table: "UsersTech",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "UserId",
            //    table: "Wallet",
            //    column: "UserId",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__EFMigrationsHistory");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GroupsQuests");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "UserInventory");

            migrationBuilder.DropTable(
                name: "UsersQuests");

            migrationBuilder.DropTable(
                name: "UsersTech");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
