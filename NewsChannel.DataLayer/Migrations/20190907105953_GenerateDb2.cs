using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsChannel.DataLayer.Migrations
{
    public partial class GenerateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDateTime",
                table: "AppUsers",
                nullable: true,
                defaultValueSql: "CONVERT(datetime,GetDate())",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AppUsers",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AppUsers",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDateTime",
                table: "AppUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "CONVERT(datetime,GetDate())");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AppUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AppUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
