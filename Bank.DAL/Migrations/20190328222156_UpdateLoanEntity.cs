using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.DAL.Migrations
{
    public partial class UpdateLoanEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpDate",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WasReplenished",
                table: "Loans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CardId",
                table: "Loans",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Cards_CardId",
                table: "Loans",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Cards_CardId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CardId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "WasReplenished",
                table: "Loans");

            migrationBuilder.AlterColumn<double>(
                name: "Percent",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "Money",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "ExpDate",
                table: "Loans",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                table: "Loans",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
