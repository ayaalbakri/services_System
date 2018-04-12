using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuestApp.Migrations
{
    public partial class Add_Enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TreatmentTitle",
                table: "Treatments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TreatmentTitle",
                table: "Treatments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
