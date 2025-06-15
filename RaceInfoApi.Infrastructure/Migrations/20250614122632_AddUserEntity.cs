using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RaceInfoApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "raceresults");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "races");
        }
    }
}
