using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingInChetu.Migrations
{
    public partial class msd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_LocationId",
                table: "customers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_Locations_LocationId",
                table: "customers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_Locations_LocationId",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_LocationId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "customers");
        }
    }
}
