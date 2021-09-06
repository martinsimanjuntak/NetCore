using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore1.Migrations
{
    public partial class AddtableRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonViewModels",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NamaDepan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaBelakang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education_id = table.Column<int>(type: "int", nullable: false),
                    Unversity_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TglLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonViewModels", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_universities   ",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_universities   ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Univesity_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_educations_tb_m_universities   _UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "tb_m_universities   ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_profilings",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Education_id = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_profilings", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_profilings_tb_m_educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "tb_m_educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roleaccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roleaccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_persons",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_persons", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_persons_tb_m_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_persons_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_persons",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_educations_UniversityId",
                table: "tb_m_educations",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_persons_RoleId",
                table: "tb_m_persons",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_profilings_EducationId",
                table: "tb_m_profilings",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_roleaccounts_AccountNIK",
                table: "tb_m_roleaccounts",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_roleaccounts_RoleId",
                table: "tb_m_roleaccounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_roles_AccountNIK",
                table: "tb_m_roles",
                column: "AccountNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_profilings_tb_m_accounts_NIK",
                table: "tb_m_profilings",
                column: "NIK",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_roles_tb_m_accounts_AccountNIK",
                table: "tb_m_roles",
                column: "AccountNIK",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accounts_tb_m_persons_NIK",
                table: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "PersonViewModels");

            migrationBuilder.DropTable(
                name: "tb_m_profilings");

            migrationBuilder.DropTable(
                name: "tb_m_roleaccounts");

            migrationBuilder.DropTable(
                name: "tb_m_educations");

            migrationBuilder.DropTable(
                name: "tb_m_universities   ");

            migrationBuilder.DropTable(
                name: "tb_m_persons");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");
        }
    }
}
