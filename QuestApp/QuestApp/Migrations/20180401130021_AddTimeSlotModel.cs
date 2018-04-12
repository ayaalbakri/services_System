using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuestApp.Migrations
{
    public partial class AddTimeSlotModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_LU_TimeSlot_TimeSlotId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LU_TimeSlot",
                table: "LU_TimeSlot");

            migrationBuilder.RenameTable(
                name: "LU_TimeSlot",
                newName: "TimeSlots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotId",
                table: "Bookings",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots");

            migrationBuilder.RenameTable(
                name: "TimeSlots",
                newName: "LU_TimeSlot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LU_TimeSlot",
                table: "LU_TimeSlot",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_LU_TimeSlot_TimeSlotId",
                table: "Bookings",
                column: "TimeSlotId",
                principalTable: "LU_TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
