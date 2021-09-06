using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore1.Migrations
{
    public partial class person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tb_m_persons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "tb_m_persons");
        }
    }
}
