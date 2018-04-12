using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuestApp.Migrations
{
    public partial class EditInContextFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Restaurants_TreatmentId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Treatments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Treatments_TreatmentId",
                table: "Bookings",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Treatments_TreatmentId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments");

            migrationBuilder.RenameTable(
                name: "Treatments",
                newName: "Restaurants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Restaurants_TreatmentId",
                table: "Bookings",
                column: "TreatmentId",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
