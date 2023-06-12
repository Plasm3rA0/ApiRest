using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class SolucionDeProblemaConRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surnames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "age", "creationDate", "email", "imageUrl", "name", "password", "surnames", "updateDate", "username" },
                values: new object[,]
                {
                    { 1, 18, new DateTime(2023, 6, 11, 9, 56, 16, 776, DateTimeKind.Local).AddTicks(2632), "phernancamino@insllica.cat", "", "Pol", "Alumne1234.", "Hernan Camino", new DateTime(2023, 6, 11, 9, 56, 16, 776, DateTimeKind.Local).AddTicks(2682), "polhernan" },
                    { 2, 18, new DateTime(2023, 6, 11, 9, 56, 16, 776, DateTimeKind.Local).AddTicks(2687), "vlainezliso@insllica.cat", "", "Veronica", "Alumne1234.", "Lainez Liso", new DateTime(2023, 6, 11, 9, 56, 16, 776, DateTimeKind.Local).AddTicks(2689), "vero" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
