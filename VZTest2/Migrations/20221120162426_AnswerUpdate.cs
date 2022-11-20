using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VZTest2.Migrations
{
    /// <inheritdoc />
    public partial class AnswerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CorrectDate",
                table: "Questions",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CorrectDouble",
                table: "Questions",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectInt",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectText",
                table: "Questions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectDouble",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectInt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectText",
                table: "Questions");
        }
    }
}
