using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "EventConfigurations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "ActivityHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "EventConfigurations");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "ActivityHistory");
        }
    }
}
