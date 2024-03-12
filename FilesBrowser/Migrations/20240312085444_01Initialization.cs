using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilesBrowser.Migrations
{
    /// <inheritdoc />
    public partial class _01Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentFolderId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderId);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Folders",
                        principalColumn: "FolderId");
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "Name", "ParentFolderId" },
                values: new object[,]
                {
                    { new Guid("6a9c035c-bfb1-43e7-a7de-d2c09dafcbfa"), "Root", null },
                    { new Guid("1b94899c-9b2f-4026-bcce-79f627faeb9b"), "Music", new Guid("6a9c035c-bfb1-43e7-a7de-d2c09dafcbfa") },
                    { new Guid("91e45580-1b20-4ea4-a62d-fbd48b93d373"), "Images", new Guid("6a9c035c-bfb1-43e7-a7de-d2c09dafcbfa") },
                    { new Guid("7ce23ddf-607d-4d91-8fa8-58ea5edd0602"), "Wallpapers", new Guid("91e45580-1b20-4ea4-a62d-fbd48b93d373") },
                    { new Guid("94820b8f-9f4f-4ed8-bfeb-a60f099404bf"), "Family", new Guid("91e45580-1b20-4ea4-a62d-fbd48b93d373") },
                    { new Guid("a104755d-a02c-4b91-a1b9-37c8180fb82d"), "Screenshots", new Guid("91e45580-1b20-4ea4-a62d-fbd48b93d373") },
                    { new Guid("a888d7d1-14e1-405d-b914-13c3246f082c"), "Pop", new Guid("1b94899c-9b2f-4026-bcce-79f627faeb9b") },
                    { new Guid("cd55ec91-72a6-4e3b-927c-30cc0b4cb38b"), "Orchestral", new Guid("1b94899c-9b2f-4026-bcce-79f627faeb9b") },
                    { new Guid("f43248cd-ed46-4ca1-a2e6-2a79ed4062e1"), "Rock", new Guid("1b94899c-9b2f-4026-bcce-79f627faeb9b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
