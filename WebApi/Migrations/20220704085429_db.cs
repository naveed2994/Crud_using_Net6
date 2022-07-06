using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Fname", "ModifiedBy", "ModifiedOn", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("141f916d-0d14-41dd-981e-05ad591373e8"), new Guid("37494a26-3ae0-45e6-a44d-90ac41d87039"), new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4674), "Khan", null, null, "Sohail", "023204902843" },
                    { new Guid("508c1066-566f-4b54-ba7f-5379f0be491a"), new Guid("c6041666-f220-4eda-a1e4-baa3023bb857"), new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4601), "Khan", null, null, "Ali", "023204902843" },
                    { new Guid("80aeda5b-9b3c-4f41-9634-d356107673bd"), new Guid("2e1319be-a22e-4abd-9054-05c02e35422a"), new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4654), "Shahzad", null, null, "Hanif", "023204902843" },
                    { new Guid("8f6f8513-4e0e-4d52-ba23-b3b2898ae619"), new Guid("3619196f-8a50-45fb-ab1b-f00a5fc682de"), new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4642), "Mustaq", null, null, "Faisal", "023204902843" },
                    { new Guid("ad0c07ed-db07-431b-bfef-cdac9212b380"), new Guid("0819b03e-c449-4f4a-bf0e-f2fac63e14c0"), new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4662), "Khan", null, null, "Saif", "023204902843" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
