using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WifiUserRecorder.Migrations
{
    public partial class CreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Mac = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WifiRecords",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WifiRecords", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RecordRelations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    EquipmentID = table.Column<Guid>(nullable: false),
                    WifiRecordID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordRelations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecordRelations_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordRelations_WifiRecords_WifiRecordID",
                        column: x => x.WifiRecordID,
                        principalTable: "WifiRecords",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Mac_Name",
                table: "Equipments",
                columns: new[] { "Mac", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_RecordRelations_EquipmentID",
                table: "RecordRelations",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RecordRelations_WifiRecordID",
                table: "RecordRelations",
                column: "WifiRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_WifiRecords_DateTime",
                table: "WifiRecords",
                column: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordRelations");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "WifiRecords");
        }
    }
}
