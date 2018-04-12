using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuestApp.Migrations
{
    public partial class changTreatmentPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Treatments_TreatmentId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TreatmentId",
                table: "Bookings",
                newName: "treatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TreatmentId",
                table: "Bookings",
                newName: "IX_Bookings_treatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Treatments_treatmentId",
                table: "Bookings",
                column: "treatmentId",
                principalTable: "Treatments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Treatments_treatmentId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "treatmentId",
                table: "Bookings",
                newName: "TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_treatmentId",
                table: "Bookings",
                newName: "IX_Bookings_TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Treatments_TreatmentId",
                table: "Bookings",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
