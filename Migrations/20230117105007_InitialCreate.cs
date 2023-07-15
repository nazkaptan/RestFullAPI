using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestFullAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Password", "Status", "UpdateDate", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 17, 13, 50, 6, 993, DateTimeKind.Local).AddTicks(2432), null, "123", 1, null, "beast" },
                    { 2, new DateTime(2023, 1, 17, 13, 50, 6, 993, DateTimeKind.Local).AddTicks(3167), null, "123", 1, null, "savage" },
                    { 3, new DateTime(2023, 1, 17, 13, 50, 6, 993, DateTimeKind.Local).AddTicks(3174), null, "123", 1, null, "raider" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "Name", "Slug", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 17, 13, 50, 6, 989, DateTimeKind.Local).AddTicks(8738), null, "Best MMA boxing gloves here..!", "UFC Gloves", "ufc-gloves", 1, null },
                    { 2, new DateTime(2023, 1, 17, 13, 50, 6, 991, DateTimeKind.Local).AddTicks(6562), null, "Best MMA equipments here..!", "Protected Equipment", "protected-equipment", 1, null },
                    { 3, new DateTime(2023, 1, 17, 13, 50, 6, 991, DateTimeKind.Local).AddTicks(6581), null, "Best MMA bandages here..!", "Hand Wraps", "hand-wraps", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
