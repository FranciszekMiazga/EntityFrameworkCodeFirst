using Microsoft.EntityFrameworkCore.Migrations;

namespace EFWebApplicationCodeFirst.Migrations
{
    public partial class AddMoreDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 2, "nowak@wp.pl", "Mateusz", "Nowak" },
                    { 3, "modzel@gmail.com", "Grzegorz", "Modzelewski" },
                    { 4, "piter@wp.pl", "Adam", "Piotrkowski" },
                    { 5, "drzazga@wp.pl", "Natalia", "Drzazga" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 5);
        }
    }
}
