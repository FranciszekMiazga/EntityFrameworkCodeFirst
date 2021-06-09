using Microsoft.EntityFrameworkCore.Migrations;

namespace EFWebApplicationCodeFirst.Migrations
{
    public partial class AddMedicaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "abs", "Pfizer", "typeA" },
                    { 2, "rda", "Astrazeneca", "typeB" },
                    { 3, "bda", "Paracetamol", "typeC" },
                    { 4, "www", "Rutinoscorbin", "typeD" },
                    { 5, "hgd", "Aspirin", "typeE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 5);
        }
    }
}
