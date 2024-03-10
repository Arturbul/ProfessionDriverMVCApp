﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entitys",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entitys", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicys",
                columns: table => new
                {
                    InsurancePolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    DateTo = table.Column<DateOnly>(type: "date", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicys", x => x.InsurancePolicyId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleInspections",
                columns: table => new
                {
                    VehicleInspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DateFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    DateTo = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInspections", x => x.VehicleInspectionId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    TerminationDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Entitys_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entitys",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleInsurances",
                columns: table => new
                {
                    VehicleInsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    OC_PolicyInsurancePolicyId = table.Column<int>(type: "int", nullable: false),
                    AC_PolicyInsurancePolicyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInsurances", x => x.VehicleInsuranceId);
                    table.ForeignKey(
                        name: "FK_VehicleInsurances_InsurancePolicys_AC_PolicyInsurancePolicyId",
                        column: x => x.AC_PolicyInsurancePolicyId,
                        principalTable: "InsurancePolicys",
                        principalColumn: "InsurancePolicyId");
                    table.ForeignKey(
                        name: "FK_VehicleInsurances_InsurancePolicys_OC_PolicyInsurancePolicyId",
                        column: x => x.OC_PolicyInsurancePolicyId,
                        principalTable: "InsurancePolicys",
                        principalColumn: "InsurancePolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufactureYear = table.Column<int>(type: "int", nullable: true),
                    VehicleInsuranceId = table.Column<int>(type: "int", nullable: true),
                    VehicleInspectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Entitys_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entitys",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleInspections_VehicleInspectionId",
                        column: x => x.VehicleInspectionId,
                        principalTable: "VehicleInspections",
                        principalColumn: "VehicleInspectionId");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleInsurances_VehicleInsuranceId",
                        column: x => x.VehicleInsuranceId,
                        principalTable: "VehicleInsurances",
                        principalColumn: "VehicleInsuranceId");
                });

            migrationBuilder.CreateTable(
                name: "DriverWorkLogEntrys",
                columns: table => new
                {
                    DriverWorkLogEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverWorkLogEntrys", x => x.DriverWorkLogEntryId);
                    table.ForeignKey(
                        name: "FK_DriverWorkLogEntrys_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LargeGoodsVehicles",
                columns: table => new
                {
                    LargeGoodsVehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TrailerId = table.Column<int>(type: "int", nullable: true),
                    TachoExpiryDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LargeGoodsVehicles", x => x.LargeGoodsVehicleId);
                    table.ForeignKey(
                        name: "FK_LargeGoodsVehicles_Vehicles_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                    table.ForeignKey(
                        name: "FK_LargeGoodsVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverWorkLogs",
                columns: table => new
                {
                    DriverWorkLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    StartDriverWorkLogEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndDriverWorkLogEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LargeGoodsVehicleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverWorkLogs", x => x.DriverWorkLogId);
                    table.ForeignKey(
                        name: "FK_DriverWorkLogs_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverWorkLogs_LargeGoodsVehicles_LargeGoodsVehicleId",
                        column: x => x.LargeGoodsVehicleId,
                        principalTable: "LargeGoodsVehicles",
                        principalColumn: "LargeGoodsVehicleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_EmployeeId",
                table: "Drivers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverWorkLogEntrys_DriverId",
                table: "DriverWorkLogEntrys",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverWorkLogs_DriverId",
                table: "DriverWorkLogs",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverWorkLogs_LargeGoodsVehicleId",
                table: "DriverWorkLogs",
                column: "LargeGoodsVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EntityId",
                table: "Employees",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LargeGoodsVehicles_TrailerId",
                table: "LargeGoodsVehicles",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_LargeGoodsVehicles_VehicleId",
                table: "LargeGoodsVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInsurances_AC_PolicyInsurancePolicyId",
                table: "VehicleInsurances",
                column: "AC_PolicyInsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInsurances_OC_PolicyInsurancePolicyId",
                table: "VehicleInsurances",
                column: "OC_PolicyInsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EntityId",
                table: "Vehicles",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleInspectionId",
                table: "Vehicles",
                column: "VehicleInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleInsuranceId",
                table: "Vehicles",
                column: "VehicleInsuranceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverWorkLogEntrys");

            migrationBuilder.DropTable(
                name: "DriverWorkLogs");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "LargeGoodsVehicles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Entitys");

            migrationBuilder.DropTable(
                name: "VehicleInspections");

            migrationBuilder.DropTable(
                name: "VehicleInsurances");

            migrationBuilder.DropTable(
                name: "InsurancePolicys");
        }
    }
}
