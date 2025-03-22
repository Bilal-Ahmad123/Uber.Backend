using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: false),
                    BaseFare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RatePerKM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleMake = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    VehicleColor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VehiclePlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllVehicleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_AllVehicles_AllVehicleModelId",
                        column: x => x.AllVehicleModelId,
                        principalTable: "AllVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AllVehicleModelId",
                table: "Vehicles",
                column: "AllVehicleModelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AllVehicles");
        }
    }
}
