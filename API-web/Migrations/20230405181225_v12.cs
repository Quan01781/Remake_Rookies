using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_web.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "Products",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "Update_By",
                table: "Products",
                newName: "Updated_by");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "Products",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "Create_By",
                table: "Products",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "Images",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "Update_By",
                table: "Images",
                newName: "Updated_by");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "Images",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "Create_By",
                table: "Images",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "Categories",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "Update_By",
                table: "Categories",
                newName: "Updated_by");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "Categories",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "Create_By",
                table: "Categories",
                newName: "Created_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_by",
                table: "Products",
                newName: "Update_By");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Products",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "Products",
                newName: "Create_By");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Products",
                newName: "Create_Date");

            migrationBuilder.RenameColumn(
                name: "Updated_by",
                table: "Images",
                newName: "Update_By");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Images",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "Images",
                newName: "Create_By");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Images",
                newName: "Create_Date");

            migrationBuilder.RenameColumn(
                name: "Updated_by",
                table: "Categories",
                newName: "Update_By");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Categories",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "Categories",
                newName: "Create_By");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Categories",
                newName: "Create_Date");
        }
    }
}
