using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    creationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Title", "creationDate", "dueDate", "priority", "status" },
                values: new object[,]
                {
                    { 1, "Write and complete the project documentation.", "Complete Documentation", new DateOnly(2024, 11, 29), new DateOnly(2024, 12, 15), 2, false },
                    { 2, "Review the code before submission.", "Code Review", new DateOnly(2024, 11, 25), new DateOnly(2024, 12, 10), 1, false },
                    { 3, "Test the functionality of the project.", "Testing", new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 5), 0, true },
                    { 4, "Discuss the project requirements with the client.", "Client Meeting", new DateOnly(2024, 11, 30), new DateOnly(2024, 12, 1), 2, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
