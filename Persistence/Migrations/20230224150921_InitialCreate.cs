using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuoteRequestData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    ParcelWidth = table.Column<decimal>(type: "TEXT", nullable: false),
                    ParcelHeight = table.Column<decimal>(type: "TEXT", nullable: false),
                    ParcelLength = table.Column<decimal>(type: "TEXT", nullable: false),
                    ParcelWeight = table.Column<decimal>(type: "TEXT", nullable: false),
                    CompanySupplier = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyFound = table.Column<bool>(type: "INTEGER", nullable: false),
                    MostCompetitiveRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateAndTimeOfOrder = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteRequestData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteRequestData");
        }
    }
}
