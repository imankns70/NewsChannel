using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsChannel.DataLayer.Migrations
{
    public partial class UpdateNewsLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDateTime",
                table: "NewsLetters",
                nullable: true,
                defaultValueSql: "CONVERT(datetime,GetDate())",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "NewsLetters",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDateTime",
                table: "NewsLetters",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "CONVERT(datetime,GetDate())");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "NewsLetters",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");
        }
    }
}
