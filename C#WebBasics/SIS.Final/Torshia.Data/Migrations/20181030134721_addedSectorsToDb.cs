using Microsoft.EntityFrameworkCore.Migrations;

namespace Torshia.Data.Migrations
{
    public partial class addedSectorsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSectors_Sector_SectorId",
                table: "TaskSectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sector",
                table: "Sector");

            migrationBuilder.RenameTable(
                name: "Sector",
                newName: "Sectors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sectors",
                table: "Sectors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSectors_Sectors_SectorId",
                table: "TaskSectors",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSectors_Sectors_SectorId",
                table: "TaskSectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sectors",
                table: "Sectors");

            migrationBuilder.RenameTable(
                name: "Sectors",
                newName: "Sector");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sector",
                table: "Sector",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSectors_Sector_SectorId",
                table: "TaskSectors",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
