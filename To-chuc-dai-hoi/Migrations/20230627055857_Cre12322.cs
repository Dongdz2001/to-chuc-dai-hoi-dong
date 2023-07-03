using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_chuc_dai_hoi.Migrations
{
    /// <inheritdoc />
    public partial class Cre12322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleChooses",
                table: "PeopleChooses");

            migrationBuilder.RenameTable(
                name: "PeopleChooses",
                newName: "PeopleChooseProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleChooseProducts",
                table: "PeopleChooseProducts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleChooseProducts",
                table: "PeopleChooseProducts");

            migrationBuilder.RenameTable(
                name: "PeopleChooseProducts",
                newName: "PeopleChooses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleChooses",
                table: "PeopleChooses",
                column: "Id");
        }
    }
}
