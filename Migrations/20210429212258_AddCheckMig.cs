using Microsoft.EntityFrameworkCore.Migrations;

namespace EFWebApplicationCodeFirst.Migrations
{
    public partial class AddCheckMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "Details", "Dose", "IdPrescription" },
                values: new object[] { 3, "gdasprawdz", 21, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);
        }
    }
}
