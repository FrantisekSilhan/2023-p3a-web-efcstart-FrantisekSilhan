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
                    ParentFolderId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderId);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Folders",
                        principalColumn: "FolderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "Name", "ParentFolderId" },
                values: new object[,]
                {
                    { new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb"), "Root", new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb") },
                    { new Guid("15c3694b-32e1-478d-96ed-86873a3396f3"), "Music", new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb") },
                    { new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d"), "Images", new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb") },
                    { new Guid("0d84a9eb-e863-46f1-a96f-c98ccbd04c26"), "Wallpapers", new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d") },
                    { new Guid("10e85872-ada5-4d9c-9fae-221117a68f48"), "Pop", new Guid("15c3694b-32e1-478d-96ed-86873a3396f3") },
                    { new Guid("4fe5143e-c32d-4c09-b589-e3ef46ddefd4"), "Rock", new Guid("15c3694b-32e1-478d-96ed-86873a3396f3") },
                    { new Guid("90969de0-de02-4606-85eb-48670193830c"), "Screenshots", new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d") },
                    { new Guid("aa3b5248-f54e-4940-adab-c8e68db50d13"), "Family", new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d") },
                    { new Guid("d393b30a-7fec-46a6-8318-fb93fb4076a9"), "Orchestral", new Guid("15c3694b-32e1-478d-96ed-86873a3396f3") }
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
