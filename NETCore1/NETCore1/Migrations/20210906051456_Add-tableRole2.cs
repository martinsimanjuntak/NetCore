using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore1.Migrations
{
    public partial class AddtableRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_persons_tb_m_roles_RoleId",
                table: "tb_m_persons");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_roles_tb_m_accounts_AccountNIK",
                table: "tb_m_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_roles_AccountNIK",
                table: "tb_m_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_persons_RoleId",
                table: "tb_m_persons");

            migrationBuilder.DropColumn(
                name: "AccountNIK",
                table: "tb_m_roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "tb_m_persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNIK",
                table: "tb_m_roles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "tb_m_persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_roles_AccountNIK",
                table: "tb_m_roles",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_persons_RoleId",
                table: "tb_m_persons",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_persons_tb_m_roles_RoleId",
                table: "tb_m_persons",
                column: "RoleId",
                principalTable: "tb_m_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_roles_tb_m_accounts_AccountNIK",
                table: "tb_m_roles",
                column: "AccountNIK",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
