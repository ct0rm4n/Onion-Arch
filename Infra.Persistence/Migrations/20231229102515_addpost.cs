using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deletec",
                table: "ToDos");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    Publish = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.AddColumn<bool>(
                name: "Deletec",
                table: "ToDos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
