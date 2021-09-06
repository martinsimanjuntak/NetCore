using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore1.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_roleaccounts_tb_m_accounts_AccountNIK",
                table: "tb_m_roleaccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_roleaccounts_tb_m_roles_RoleId",
                table: "tb_m_roleaccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roleaccounts",
                table: "tb_m_roleaccounts");

            migrationBuilder.RenameTable(
                name: "tb_m_roleaccounts",
                newName: "tb_tr_role_accounts");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_roleaccounts_RoleId",
                table: "tb_tr_role_accounts",
                newName: "IX_tb_tr_role_accounts_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_roleaccounts_AccountNIK",
                table: "tb_tr_role_accounts",
                newName: "IX_tb_tr_role_accounts_AccountNIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_role_accounts",
                table: "tb_tr_role_accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_role_accounts_tb_m_accounts_AccountNIK",
                table: "tb_tr_role_accounts",
                column: "AccountNIK",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_role_accounts_tb_m_roles_RoleId",
                table: "tb_tr_role_accounts",
                column: "RoleId",
                principalTable: "tb_m_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_role_accounts_tb_m_accounts_AccountNIK",
                table: "tb_tr_role_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_role_accounts_tb_m_roles_RoleId",
                table: "tb_tr_role_accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_role_accounts",
                table: "tb_tr_role_accounts");

            migrationBuilder.RenameTable(
                name: "tb_tr_role_accounts",
                newName: "tb_m_roleaccounts");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_role_accounts_RoleId",
                table: "tb_m_roleaccounts",
                newName: "IX_tb_m_roleaccounts_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_role_accounts_AccountNIK",
                table: "tb_m_roleaccounts",
                newName: "IX_tb_m_roleaccounts_AccountNIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roleaccounts",
                table: "tb_m_roleaccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_roleaccounts_tb_m_accounts_AccountNIK",
                table: "tb_m_roleaccounts",
                column: "AccountNIK",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_roleaccounts_tb_m_roles_RoleId",
                table: "tb_m_roleaccounts",
                column: "RoleId",
                principalTable: "tb_m_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
