using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventConfigs");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "ActivityHistory");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ActivityHistory",
                newName: "StatusMessage");

            migrationBuilder.RenameColumn(
                name: "EnterpriseName",
                table: "Accounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "EnterpriseId",
                table: "Accounts",
                newName: "IdentityCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "Times",
                table: "ActivityHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EventConfigurations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteRule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListParams = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventConfigurations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventConfigurations");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "ActivityHistory");

            migrationBuilder.RenameColumn(
                name: "StatusMessage",
                table: "ActivityHistory",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Accounts",
                newName: "EnterpriseName");

            migrationBuilder.RenameColumn(
                name: "IdentityCode",
                table: "Accounts",
                newName: "EnterpriseId");

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "ActivityHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventConfigs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnterpriseId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventConfigs", x => x.Id);
                });
        }
    }
}
