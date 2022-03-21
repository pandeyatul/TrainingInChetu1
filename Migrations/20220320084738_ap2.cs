using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingInChetu.Migrations
{
    public partial class ap2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_Locations_locationId",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_locationId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "locationId",
                table: "customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "locationId",
                table: "customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_locationId",
                table: "customers",
                column: "locationId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_Locations_locationId",
                table: "customers",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
