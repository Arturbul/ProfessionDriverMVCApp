﻿// <auto-generated />
using System;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ProffesionDriverProjectContext))]
    [Migration("20240316141425_testContextChanges3")]
    partial class testContextChanges3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("DriverId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Domain.Models.DriverWorkLog", b =>
                {
                    b.Property<Guid>("DriverWorkLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<Guid>("EndDriverWorkLogEntryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("LargeGoodsVehicleId")
                        .HasColumnType("int");

                    b.Property<Guid>("StartDriverWorkLogEntryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DriverWorkLogId");

                    b.HasIndex("DriverId");

                    b.HasIndex("LargeGoodsVehicleId");

                    b.ToTable("DriverWorkLogs");
                });

            modelBuilder.Entity("Domain.Models.DriverWorkLogEntry", b =>
                {
                    b.Property<Guid>("DriverWorkLogEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<Guid?>("DriverWorkLogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LogTime")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Mileage")
                        .HasColumnType("real");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("DriverWorkLogEntryId");

                    b.HasIndex("DriverId");

                    b.HasIndex("DriverWorkLogId");

                    b.ToTable("DriverWorkLogEntries");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("HireDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("TerminationDate")
                        .HasColumnType("date");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EntityId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Models.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntityId"));

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Entitys");
                });

            modelBuilder.Entity("Domain.Models.InsurancePolicy", b =>
                {
                    b.Property<int>("InsurancePolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsurancePolicyId"));

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateTo")
                        .HasColumnType("date");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InsurancePolicyId");

                    b.ToTable("InsurancePolicys");
                });

            modelBuilder.Entity("Domain.Models.LargeGoodsVehicle", b =>
                {
                    b.Property<int>("LargeGoodsVehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LargeGoodsVehicleId"));

                    b.Property<DateOnly?>("TachoExpiryDate")
                        .HasColumnType("date");

                    b.Property<int?>("TrailerId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("LargeGoodsVehicleId");

                    b.HasIndex("TrailerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("LargeGoodsVehicles");
                });

            modelBuilder.Entity("Domain.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntityId")
                        .HasColumnType("int");

                    b.Property<int?>("ManufactureYear")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("VehicleInspectionId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleInsuranceId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.HasIndex("EntityId");

                    b.HasIndex("VehicleInspectionId");

                    b.HasIndex("VehicleInsuranceId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Domain.Models.VehicleInspection", b =>
                {
                    b.Property<int>("VehicleInspectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleInspectionId"));

                    b.Property<DateOnly?>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateTo")
                        .HasColumnType("date");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("VehicleInspectionId");

                    b.ToTable("VehicleInspections");
                });

            modelBuilder.Entity("Domain.Models.VehicleInsurance", b =>
                {
                    b.Property<int>("VehicleInsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleInsuranceId"));

                    b.Property<int?>("AC_PolicyInsurancePolicyId")
                        .HasColumnType("int");

                    b.Property<int>("OC_PolicyInsurancePolicyId")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("VehicleInsuranceId");

                    b.HasIndex("AC_PolicyInsurancePolicyId");

                    b.HasIndex("OC_PolicyInsurancePolicyId");

                    b.ToTable("VehicleInsurances");
                });

            modelBuilder.Entity("Domain.Models.Driver", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.DriverWorkLog", b =>
                {
                    b.HasOne("Domain.Models.Driver", "Driver")
                        .WithMany("DriverWorkLogs")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.LargeGoodsVehicle", null)
                        .WithMany("DriverWorkLogs")
                        .HasForeignKey("LargeGoodsVehicleId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Domain.Models.DriverWorkLogEntry", b =>
                {
                    b.HasOne("Domain.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.DriverWorkLog", "DriverWorkLog")
                        .WithMany()
                        .HasForeignKey("DriverWorkLogId");

                    b.Navigation("Driver");

                    b.Navigation("DriverWorkLog");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.HasOne("Domain.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("Domain.Models.LargeGoodsVehicle", b =>
                {
                    b.HasOne("Domain.Models.Vehicle", "Trailer")
                        .WithMany()
                        .HasForeignKey("TrailerId");

                    b.HasOne("Domain.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trailer");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Domain.Models.Vehicle", b =>
                {
                    b.HasOne("Domain.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.HasOne("Domain.Models.VehicleInspection", "VehicleInspection")
                        .WithMany()
                        .HasForeignKey("VehicleInspectionId");

                    b.HasOne("Domain.Models.VehicleInsurance", "VehicleInsurance")
                        .WithMany()
                        .HasForeignKey("VehicleInsuranceId");

                    b.Navigation("Entity");

                    b.Navigation("VehicleInspection");

                    b.Navigation("VehicleInsurance");
                });

            modelBuilder.Entity("Domain.Models.VehicleInsurance", b =>
                {
                    b.HasOne("Domain.Models.InsurancePolicy", "AC_Policy")
                        .WithMany()
                        .HasForeignKey("AC_PolicyInsurancePolicyId");

                    b.HasOne("Domain.Models.InsurancePolicy", "OC_Policy")
                        .WithMany()
                        .HasForeignKey("OC_PolicyInsurancePolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AC_Policy");

                    b.Navigation("OC_Policy");
                });

            modelBuilder.Entity("Domain.Models.Driver", b =>
                {
                    b.Navigation("DriverWorkLogs");
                });

            modelBuilder.Entity("Domain.Models.LargeGoodsVehicle", b =>
                {
                    b.Navigation("DriverWorkLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
