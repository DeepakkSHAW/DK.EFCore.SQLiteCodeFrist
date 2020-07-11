using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DK.EFCore.SQLiteCodeFrist.Data.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_AMC",
                columns: table => new
                {
                    AMCId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AMCTitle = table.Column<string>(maxLength: 100, nullable: false),
                    inDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AMC", x => x.AMCId);
                });

            migrationBuilder.CreateTable(
                name: "T_MF",
                columns: table => new
                {
                    MutualFundId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MutualFundName = table.Column<string>(maxLength: 100, nullable: false),
                    AMCId = table.Column<int>(nullable: true),
                    inDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MF", x => x.MutualFundId);
                    table.ForeignKey(
                        name: "FK_T_MF_T_AMC_AMCId",
                        column: x => x.AMCId,
                        principalTable: "T_AMC",
                        principalColumn: "AMCId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "T_AMC",
                columns: new[] { "AMCId", "AMCTitle", "inDate" },
                values: new object[] { 1, "OM test AMC", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_T_MF_AMCId",
                table: "T_MF",
                column: "AMCId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_MF");

            migrationBuilder.DropTable(
                name: "T_AMC");
        }
    }
}
