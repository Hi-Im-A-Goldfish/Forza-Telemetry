using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForzaTelemetryServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrackedRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackedRoutes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrackedRoutePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TrackedRouteId = table.Column<int>(type: "int", nullable: false),
                    PositionX = table.Column<float>(type: "float", nullable: false),
                    PositionY = table.Column<float>(type: "float", nullable: false),
                    PositionZ = table.Column<float>(type: "float", nullable: false),
                    TireTempFl = table.Column<float>(type: "float", nullable: false),
                    TireTempFr = table.Column<float>(type: "float", nullable: false),
                    TireTempRl = table.Column<float>(type: "float", nullable: false),
                    TireTempRr = table.Column<float>(type: "float", nullable: false),
                    TireSlipAngleFrontLeft = table.Column<float>(type: "float", nullable: false),
                    TireSlipAngleFrontRight = table.Column<float>(type: "float", nullable: false),
                    TireSlipAngleRearLeft = table.Column<float>(type: "float", nullable: false),
                    TireSlipAngleRearRight = table.Column<float>(type: "float", nullable: false),
                    TimestampMS = table.Column<uint>(type: "int unsigned", nullable: false),
                    IsRaceOn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EngineMaxRpm = table.Column<float>(type: "float", nullable: false),
                    CurrentEngineRpm = table.Column<float>(type: "float", nullable: false),
                    GForceVector = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GForceValue = table.Column<double>(type: "double", nullable: false),
                    Speed = table.Column<float>(type: "float", nullable: false),
                    Power = table.Column<float>(type: "float", nullable: false),
                    Torque = table.Column<float>(type: "float", nullable: false),
                    Accelerator = table.Column<float>(type: "float", nullable: false),
                    Brake = table.Column<float>(type: "float", nullable: false),
                    Gear = table.Column<uint>(type: "int unsigned", nullable: false),
                    Steer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackedRoutePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackedRoutePoints_TrackedRoutes_TrackedRouteId",
                        column: x => x.TrackedRouteId,
                        principalTable: "TrackedRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TrackedRoutePoints_TrackedRouteId",
                table: "TrackedRoutePoints",
                column: "TrackedRouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackedRoutePoints");

            migrationBuilder.DropTable(
                name: "TrackedRoutes");
        }
    }
}
