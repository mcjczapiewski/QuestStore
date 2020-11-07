using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Migrations
{
    public partial class GroupInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Wallet",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ItemUsed",
                table: "UserInventory",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "GroupBank",
                table: "Groups",
                type: "decimal(10,2)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "GroupsInventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemUsed = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsInventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_GroupsInventory_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsInventory_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsInventory_GroupId",
                table: "GroupsInventory",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsInventory_ItemId",
                table: "GroupsInventory",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupsInventory");

            migrationBuilder.DropColumn(
                name: "ItemUsed",
                table: "UserInventory");

            migrationBuilder.DropColumn(
                name: "GroupBank",
                table: "Groups");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Wallet",
                type: "double(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);
        }
    }
}
