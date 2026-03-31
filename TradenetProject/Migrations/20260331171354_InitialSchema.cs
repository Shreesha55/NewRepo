using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradenetProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplianceRecords",
                columns: table => new
                {
                    ComplianceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceRecords", x => x.ComplianceID);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentID);
                });

            migrationBuilder.CreateTable(
                name: "MarketRecords",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalVendors = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revenue = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketRecords", x => x.RecordID);
                });

            migrationBuilder.CreateTable(
                name: "TradeLicenses",
                columns: table => new
                {
                    LicenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeLicenses", x => x.LicenseID);
                });

            migrationBuilder.CreateTable(
                name: "TradeOfficers",
                columns: table => new
                {
                    OfficerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeOfficers", x => x.OfficerID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                });

            migrationBuilder.InsertData(
                table: "ComplianceRecords",
                columns: new[] { "ComplianceID", "BusinessName", "InspectedBy", "InspectedDate", "InspectionType", "Remarks", "Result" },
                values: new object[,]
                {
                    { 1, "ABC Traders", "Trade Officer", "2026-01-05", "Annual Audit", "All documents in order, no violations found.", "Passed" },
                    { 2, "XYZ Exports", "Trade Officer", "2026-01-10", "Safety Inspection", "Minor safety signage missing, corrective notice issued.", "Failed" },
                    { 3, "Global Imports Ltd", "Trade Officer", "2026-01-12", "License Compliance", "Operating license valid, import permits verified.", "Passed" },
                    { 4, "Eastern Commerce", "", "2026-01-18", "Tax Compliance", "", "Pending" },
                    { 5, "Pacific Wholesale", "", "2026-01-20", "Environmental Check", "", "Pending" },
                    { 6, "Sunrise Trading Co", "Trade Officer", "2025-12-28", "Annual Audit", "Expired trade certificate, renewal required.", "Failed" },
                    { 7, "Delta Freight", "Trade Officer", "2026-02-01", "Safety Inspection", "Fire extinguishers up to date, exits clearly marked.", "Passed" },
                    { 8, "Coastal Ventures", "Trade Officer", "2026-02-05", "License Compliance", "Export license expired, renewal in progress.", "Failed" },
                    { 9, "Metro Distributors", "", "2026-02-08", "Tax Compliance", "", "Pending" },
                    { 10, "Summit Logistics", "Trade Officer", "2026-02-10", "Annual Audit", "All regulatory filings current, warehouse standards met.", "Passed" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentID", "BusinessName", "DocumentType", "Status", "SubmittedDate", "VerifiedBy" },
                values: new object[,]
                {
                    { 1, "ABC Traders", "Trade Certificate", "Pending", "2026-01-10", "" },
                    { 2, "XYZ Exports", "Tax Clearance", "Pending", "2026-01-12", "" },
                    { 3, "Global Imports Ltd", "Import Permit", "Verified", "2026-01-08", "Trade Officer" },
                    { 4, "Eastern Commerce", "Business Registration", "Pending", "2026-01-15", "" },
                    { 5, "Pacific Wholesale", "Export License", "Rejected", "2026-01-05", "Trade Officer" },
                    { 6, "Sunrise Trading Co", "Trade Certificate", "Verified", "2026-01-18", "Trade Officer" },
                    { 7, "Delta Freight", "Tax Clearance", "Pending", "2026-01-20", "" },
                    { 8, "Coastal Ventures", "Import Permit", "Verified", "2026-01-22", "Trade Officer" },
                    { 9, "Metro Distributors", "Business Registration", "Rejected", "2026-01-25", "Trade Officer" },
                    { 10, "Summit Logistics", "Export License", "Pending", "2026-01-28", "" }
                });

            migrationBuilder.InsertData(
                table: "MarketRecords",
                columns: new[] { "RecordID", "Category", "Location", "MarketName", "Revenue", "Status", "TotalVendors" },
                values: new object[,]
                {
                    { 1, "Wholesale", "Downtown District", "Central Trade Market", 450000.0, "Active", 124 },
                    { 2, "Export", "Harbor Zone", "Eastern Export Hub", 320000.0, "Active", 86 },
                    { 3, "Retail", "South Bank", "Riverside Market", 125000.0, "Under Review", 45 },
                    { 4, "Import", "Industrial Park", "North Import Center", 275000.0, "Active", 67 },
                    { 5, "Retail", "West End", "Sunset Bazaar", 85000.0, "Inactive", 32 },
                    { 6, "Wholesale", "Uptown Heights", "Hilltop Trade Plaza", 390000.0, "Active", 98 },
                    { 7, "Import", "Lake District", "Lakeside Commerce Park", 210000.0, "Active", 53 },
                    { 8, "Retail", "Heritage Quarter", "Old Town Market", 72000.0, "Under Review", 28 },
                    { 9, "Export", "Airport Road", "Greenfield Export Zone", 415000.0, "Active", 74 },
                    { 10, "Wholesale", "Coastal Strip", "Bayview Trading Center", 165000.0, "Inactive", 41 }
                });

            migrationBuilder.InsertData(
                table: "TradeLicenses",
                columns: new[] { "LicenseID", "BusinessName", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "ABC Traders", "Pending", "Import" },
                    { 2, "XYZ Exports", "Pending", "Export" },
                    { 3, "Global Imports Ltd", "Approved", "Import" },
                    { 4, "Eastern Commerce", "Approved", "Export" },
                    { 5, "Pacific Wholesale", "Rejected", "Import" },
                    { 6, "Sunrise Trading Co", "Approved", "Export" },
                    { 7, "Delta Freight", "Pending", "Import" },
                    { 8, "Coastal Ventures", "Approved", "Export" },
                    { 9, "Metro Distributors", "Pending", "Import" },
                    { 10, "Summit Logistics", "Rejected", "Export" }
                });

            migrationBuilder.InsertData(
                table: "TradeOfficers",
                columns: new[] { "OfficerID", "DateOfJoining", "Department", "Designation", "Email", "EmployeeCode", "FullName", "Phone", "Region", "Status" },
                values: new object[] { 1001, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trade Licensing & Compliance", "Senior Trade Officer", "officer@tradenet.gov", "TO-2024-1001", "Trade Officer", "+1 (800) 555-0142", "North America – Eastern Division", "Active" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "Amount", "BusinessName", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 5000.0, "ABC Traders", "Completed", "Sale" },
                    { 2, 8000.0, "XYZ Exports", "Pending", "Purchase" },
                    { 3, 12500.0, "Global Imports Ltd", "Completed", "Sale" },
                    { 4, 3200.0, "Eastern Commerce", "Completed", "Purchase" },
                    { 5, 9750.0, "Pacific Wholesale", "Pending", "Sale" },
                    { 6, 15000.0, "Sunrise Trading Co", "Completed", "Purchase" },
                    { 7, 6800.0, "Delta Freight", "Pending", "Sale" },
                    { 8, 22000.0, "Coastal Ventures", "Completed", "Purchase" },
                    { 9, 4100.0, "Metro Distributors", "Completed", "Sale" },
                    { 10, 18500.0, "Summit Logistics", "Pending", "Purchase" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplianceRecords");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "MarketRecords");

            migrationBuilder.DropTable(
                name: "TradeLicenses");

            migrationBuilder.DropTable(
                name: "TradeOfficers");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
