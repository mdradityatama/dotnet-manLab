using Microsoft.EntityFrameworkCore.Migrations;

namespace ManLab.Migrations
{
    public partial class Collection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    ToolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ToolID);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionID);
                    table.ForeignKey(
                        name: "FK_Collections_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collections_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collections_Tools_ToolID",
                        column: x => x.ToolID,
                        principalTable: "Tools",
                        principalColumn: "ToolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Tetap" },
                    { 2, "Habis Pakai" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "Name" },
                values: new object[,]
                {
                    { 1, "R01" },
                    { 2, "R02" },
                    { 3, "R03" },
                    { 4, "R04" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ToolID", "Name" },
                values: new object[,]
                {
                    { 1, "Kursi" },
                    { 2, "Meja" },
                    { 3, "Spidol" },
                    { 4, "Penghapus" }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionID", "CategoryID", "RoomID", "ToolID", "Total" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 10 },
                    { 2, 2, 2, 2, 20 },
                    { 5, 1, 1, 2, 50 },
                    { 3, 1, 3, 3, 30 },
                    { 4, 2, 4, 4, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryID",
                table: "Collections",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_RoomID",
                table: "Collections",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_ToolID",
                table: "Collections",
                column: "ToolID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Tools");
        }
    }
}
