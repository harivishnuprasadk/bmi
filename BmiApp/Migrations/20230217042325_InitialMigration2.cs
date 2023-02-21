using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BmiApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BmiUserHealthData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BmiUserHealthData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BmiUserData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BmiUserData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BmiMetrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BmiMetrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BmiUserHealthData");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BmiUserHealthData");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BmiUserData");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BmiUserData");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BmiMetrics");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BmiMetrics");
        }
    }
}
