using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFWebApplicationCodeFirst.Migrations
{
    public partial class AddPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" },
                    { 2, new DateTime(1998, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mateusz", "Nowak" },
                    { 3, new DateTime(1981, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grzegorz", "Modzelewski" },
                    { 4, new DateTime(2002, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "Piotrkowski" },
                    { 5, new DateTime(2012, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalia", "Drzazga" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 5);
        }
    }
}
