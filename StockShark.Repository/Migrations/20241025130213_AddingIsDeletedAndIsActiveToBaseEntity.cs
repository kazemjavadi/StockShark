using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockShark.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsDeletedAndIsActiveToBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shares",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shares",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Histories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Histories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Histories");
        }
    }
}
