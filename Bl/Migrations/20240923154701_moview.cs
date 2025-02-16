using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShopPr.Migrations
{
    /// <inheritdoc />
    public partial class moview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view moview
as


SELECT        dbo.TbItems.ItemName, dbo.TbItems.ItemId, dbo.TbItems.SalesPrice, dbo.TbItems.CategoryId, dbo.TbItems.HardDisk, dbo.TbItems.Gpu, dbo.TbItems.Description, dbo.TbCategories.CategoryId AS Expr1, 
                         dbo.TbCategories.CategoryName
FROM            dbo.TbItems INNER JOIN
                         dbo.TbCategories ON dbo.TbItems.CategoryId = dbo.TbCategories.CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
        }
    }
}
