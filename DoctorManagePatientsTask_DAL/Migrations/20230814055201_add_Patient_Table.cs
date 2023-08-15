using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorManagePatientsTask_Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_Patient_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Forenames = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SexCode = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    HomeTelephoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NokName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NokRelationshipCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NokAddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NokAddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NokAddressLine3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NokAddressLine4 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NokPostcode = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    GpCode = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    GpSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GpInitials = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GpPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorAccountId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ModifierAccountId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifictionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
