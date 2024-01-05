using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunningStats.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunningModel",
                columns: table => new
                {
                    RunningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meters = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    Minutes = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningModel", x => x.RunningId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunningModel");
        }
    }
}
