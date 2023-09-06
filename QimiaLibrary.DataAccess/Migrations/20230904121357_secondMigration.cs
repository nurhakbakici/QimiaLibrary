using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QimiaLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RStatusID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                columns: table => new
                {
                    RStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.RStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RStatusID",
                table: "Reservations",
                column: "RStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationStatus_RStatusID",
                table: "Reservations",
                column: "RStatusID",
                principalTable: "ReservationStatus",
                principalColumn: "RStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationStatus_RStatusID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationStatus");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RStatusID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RStatusID",
                table: "Reservations");
        }
    }
}
