using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFWebApplicationCodeFirst.Migrations
{
    public partial class AddNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPerscription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPerscription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPerscription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "Details", "Dose", "IdPrescription" },
                values: new object[] { 2, "add", 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "Details", "Dose", "IdPrescription" },
                values: new object[] { 5, "gd", 12, 1 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "Details", "Dose", "IdPrescription" },
                values: new object[] { 1, "avs", 23, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPerscription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPerscription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPerscription",
                keyValue: 2);
        }
    }
}
