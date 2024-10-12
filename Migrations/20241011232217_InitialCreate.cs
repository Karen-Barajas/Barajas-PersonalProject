using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMaxieInn.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogReservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogReservation", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "DogInformation",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    DogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpayedOrNeutered = table.Column<bool>(type: "bit", nullable: false),
                    Vaccinated = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAccommodation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogInformation", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_DogInformation_DogReservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "DogReservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogOwner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogOwner", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_DogOwner_DogReservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "DogReservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogInformation_ReservationId",
                table: "DogInformation",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DogOwner_ReservationId",
                table: "DogOwner",
                column: "ReservationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogInformation");

            migrationBuilder.DropTable(
                name: "DogOwner");

            migrationBuilder.DropTable(
                name: "DogReservation");
        }
    }
}
