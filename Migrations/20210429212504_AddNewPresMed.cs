using Microsoft.EntityFrameworkCore.Migrations;

namespace EFWebApplicationCodeFirst.Migrations
{
    public partial class AddNewPresMed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "Details", "Dose", "IdPrescription" },
                values: new object[] { 4, "gdasprawdz", 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 4);
        }
    }
}
