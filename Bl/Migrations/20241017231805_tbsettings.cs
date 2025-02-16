﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShopPr.Migrations
{
    /// <inheritdoc />
    public partial class tbsettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebsiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaceBookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstaLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddlePanner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbSettings");
        }
    }
}
