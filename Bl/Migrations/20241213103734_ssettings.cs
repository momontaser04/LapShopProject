using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShopPr.Migrations
{
    /// <inheritdoc />
    public partial class ssettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwitterLink",
                table: "TbSettings",
                newName: "LinkedIn");

            migrationBuilder.RenameColumn(
                name: "LastPanner",
                table: "TbSettings",
                newName: "GmailLink");

            migrationBuilder.RenameColumn(
                name: "InstaLink",
                table: "TbSettings",
                newName: "GithubLink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedIn",
                table: "TbSettings",
                newName: "TwitterLink");

            migrationBuilder.RenameColumn(
                name: "GmailLink",
                table: "TbSettings",
                newName: "LastPanner");

            migrationBuilder.RenameColumn(
                name: "GithubLink",
                table: "TbSettings",
                newName: "InstaLink");
        }
    }
}
