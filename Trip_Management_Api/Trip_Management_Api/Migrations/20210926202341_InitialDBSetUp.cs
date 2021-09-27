using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trip_Management_Api.Migrations
{
    public partial class InitialDBSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.CustomerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trip_Start_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trip_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trip_End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trip_Itinerary_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCancelled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripExpense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_By = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "TripMode",
                columns: table => new
                {
                    TripModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripModeType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripMode", x => x.TripModeId);
                });

            migrationBuilder.CreateTable(
                name: "TripProperty",
                columns: table => new
                {
                    TripPropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripPropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripProperty", x => x.TripPropertyId);
                });

            migrationBuilder.CreateTable(
                name: "TripSpot",
                columns: table => new
                {
                    TripSpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripSpot", x => x.TripSpotId);
                });

            migrationBuilder.CreateTable(
                name: "TripType",
                columns: table => new
                {
                    TripTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripType", x => x.TripTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerType",
                        principalColumn: "CustomerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripDetail",
                columns: table => new
                {
                    TripDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trip_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trip_Preference_Sequence = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    TripModeId = table.Column<int>(type: "int", nullable: false),
                    TripPropertyId = table.Column<int>(type: "int", nullable: false),
                    TripSpotId = table.Column<int>(type: "int", nullable: false),
                    TripTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetail", x => x.TripDetailsId);
                    table.ForeignKey(
                        name: "FK_TripDetail_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetail_TripMode_TripModeId",
                        column: x => x.TripModeId,
                        principalTable: "TripMode",
                        principalColumn: "TripModeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetail_TripProperty_TripPropertyId",
                        column: x => x.TripPropertyId,
                        principalTable: "TripProperty",
                        principalColumn: "TripPropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetail_TripSpot_TripSpotId",
                        column: x => x.TripSpotId,
                        principalTable: "TripSpot",
                        principalColumn: "TripSpotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetail_TripType_TripTypeId",
                        column: x => x.TripTypeId,
                        principalTable: "TripType",
                        principalColumn: "TripTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripCustomer",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TripCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripCustomer", x => new { x.CustomerId, x.TripId });
                    table.ForeignKey(
                        name: "FK_TripCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripCustomer_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerType",
                columns: new[] { "CustomerTypeId", "CustomerTypeName" },
                values: new object[,]
                {
                    { 1, "Adults" },
                    { 2, "Children" },
                    { 3, "Infant" }
                });

            migrationBuilder.InsertData(
                table: "TripMode",
                columns: new[] { "TripModeId", "TripModeType" },
                values: new object[,]
                {
                    { 1, "Flights" },
                    { 2, "Trains" },
                    { 3, "Cruises" },
                    { 4, "Rental Cars" },
                    { 5, "Road Trips" }
                });

            migrationBuilder.InsertData(
                table: "TripProperty",
                columns: new[] { "TripPropertyId", "TripPropertyType" },
                values: new object[,]
                {
                    { 6, "Villa" },
                    { 5, "Resort" },
                    { 4, "Hostel" },
                    { 2, "House" },
                    { 1, "Hotels" },
                    { 3, "Apartment" }
                });

            migrationBuilder.InsertData(
                table: "TripType",
                columns: new[] { "TripTypeId", "TripTypeDescription" },
                values: new object[,]
                {
                    { 5, "Adventure" },
                    { 1, "Family_Trip" },
                    { 2, "Trip_with_friends" },
                    { 3, "Solo_Trip" },
                    { 4, "Honeymoon_Trip" },
                    { 6, "Religious" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TripCustomer_TripId",
                table: "TripCustomer",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripId",
                table: "TripDetail",
                column: "TripId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripModeId",
                table: "TripDetail",
                column: "TripModeId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripPropertyId",
                table: "TripDetail",
                column: "TripPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripSpotId",
                table: "TripDetail",
                column: "TripSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripTypeId",
                table: "TripDetail",
                column: "TripTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripCustomer");

            migrationBuilder.DropTable(
                name: "TripDetail");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "TripMode");

            migrationBuilder.DropTable(
                name: "TripProperty");

            migrationBuilder.DropTable(
                name: "TripSpot");

            migrationBuilder.DropTable(
                name: "TripType");

            migrationBuilder.DropTable(
                name: "CustomerType");
        }
    }
}
