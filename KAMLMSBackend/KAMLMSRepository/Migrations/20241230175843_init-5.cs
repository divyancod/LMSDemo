using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KAMLMSRepository.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_call_logs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_call_logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallScheduleId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_call_logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_call_logs_tbl_call_schedule_history_CallScheduleId",
                        column: x => x.CallScheduleId,
                        principalTable: "tbl_call_schedule_history",
                        principalColumn: "CallScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_call_logs_CallScheduleId",
                table: "tbl_call_logs",
                column: "CallScheduleId");
        }
    }
}
