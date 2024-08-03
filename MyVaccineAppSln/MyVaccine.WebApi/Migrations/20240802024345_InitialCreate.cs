using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVaccine.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyGroups",
                columns: table => new
                {
                    FamilyGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyGroups", x => x.FamilyGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCategories",
                columns: table => new
                {
                    VaccineCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCategories", x => x.VaccineCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "vaccines",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequireBooster = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccines", x => x.VaccineId);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergyId);
                    table.ForeignKey(
                        name: "FK_Allergies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    DependId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.DependId);
                    table.ForeignKey(
                        name: "FK_Dependents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyGroupUser",
                columns: table => new
                {
                    FamilyGroupsFamilyGroupId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyGroupUser", x => new { x.FamilyGroupsFamilyGroupId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_FamilyGroupUser_FamilyGroups_FamilyGroupsFamilyGroupId",
                        column: x => x.FamilyGroupsFamilyGroupId,
                        principalTable: "FamilyGroups",
                        principalColumn: "FamilyGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyGroupUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCategoryVaccines",
                columns: table => new
                {
                    CategoriesVaccineCategoryId = table.Column<int>(type: "int", nullable: false),
                    VaccinesVaccineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCategoryVaccines", x => new { x.CategoriesVaccineCategoryId, x.VaccinesVaccineId });
                    table.ForeignKey(
                        name: "FK_VaccineCategoryVaccines_VaccineCategories_CategoriesVaccineCategoryId",
                        column: x => x.CategoriesVaccineCategoryId,
                        principalTable: "VaccineCategories",
                        principalColumn: "VaccineCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccineCategoryVaccines_vaccines_VaccinesVaccineId",
                        column: x => x.VaccinesVaccineId,
                        principalTable: "vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vaccinesRecords",
                columns: table => new
                {
                    VaccineRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DependentId = table.Column<int>(type: "int", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    DateAdministered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministeredLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdministeredBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinesRecords", x => x.VaccineRecordId);
                    table.ForeignKey(
                        name: "FK_vaccinesRecords_Dependents_DependentId",
                        column: x => x.DependentId,
                        principalTable: "Dependents",
                        principalColumn: "DependId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vaccinesRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_vaccinesRecords_vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_UserId",
                table: "Allergies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_UserId",
                table: "Dependents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyGroupUser_UsersUserId",
                table: "FamilyGroupUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCategoryVaccines_VaccinesVaccineId",
                table: "VaccineCategoryVaccines",
                column: "VaccinesVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinesRecords_DependentId",
                table: "vaccinesRecords",
                column: "DependentId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinesRecords_UserId",
                table: "vaccinesRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinesRecords_VaccineId",
                table: "vaccinesRecords",
                column: "VaccineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "FamilyGroupUser");

            migrationBuilder.DropTable(
                name: "VaccineCategoryVaccines");

            migrationBuilder.DropTable(
                name: "vaccinesRecords");

            migrationBuilder.DropTable(
                name: "FamilyGroups");

            migrationBuilder.DropTable(
                name: "VaccineCategories");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "vaccines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
