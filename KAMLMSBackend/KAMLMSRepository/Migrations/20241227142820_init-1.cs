﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KAMLMSRepository.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardResponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentEnterpriseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_call_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_call_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_country_time_zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZoneAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtcOffset = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_country_time_zones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_kam_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_kam_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_master_login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_master_login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_poc_custom_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_poc_custom_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_poc_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_poc_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_leads_information",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentEnterpriseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHourStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHourEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_leads_information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_leads_information_tbl_kam_users_AddedById",
                        column: x => x.AddedById,
                        principalTable: "tbl_kam_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_leads_information_tbl_kam_users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "tbl_kam_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_leads_information_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_poc_contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CustomRoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_poc_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_poc_contacts_tbl_kam_users_AddedById",
                        column: x => x.AddedById,
                        principalTable: "tbl_kam_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_poc_contacts_tbl_leads_information_LeadsId",
                        column: x => x.LeadsId,
                        principalTable: "tbl_leads_information",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_poc_contacts_tbl_poc_custom_roles_CustomRoleId",
                        column: x => x.CustomRoleId,
                        principalTable: "tbl_poc_custom_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_poc_contacts_tbl_poc_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_poc_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_call_schedule_history",
                columns: table => new
                {
                    CallScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledForId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledWithId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_call_schedule_history", x => x.CallScheduleId);
                    table.ForeignKey(
                        name: "FK_tbl_call_schedule_history_tbl_call_status_CallStatusId",
                        column: x => x.CallStatusId,
                        principalTable: "tbl_call_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_call_schedule_history_tbl_kam_users_CallerId",
                        column: x => x.CallerId,
                        principalTable: "tbl_kam_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_call_schedule_history_tbl_kam_users_ScheduledById",
                        column: x => x.ScheduledById,
                        principalTable: "tbl_kam_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_call_schedule_history_tbl_leads_information_ScheduledForId",
                        column: x => x.ScheduledForId,
                        principalTable: "tbl_leads_information",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_call_schedule_history_tbl_poc_contacts_ScheduledWithId",
                        column: x => x.ScheduledWithId,
                        principalTable: "tbl_poc_contacts",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "tbl_call_status",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "ReScheduled" },
                    { 3, "Completed" },
                    { 4, "Waiting" },
                    { 5, "Answered" },
                    { 6, "NotAnswered" },
                    { 7, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "tbl_poc_custom_roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "DEFAULT" });

            migrationBuilder.InsertData(
                table: "tbl_poc_roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Director" },
                    { 3, "Manager" },
                    { 4, "SalesManager" },
                    { 5, "AssistantManager" },
                    { 6, "OperationsManager" },
                    { 7, "Receptionist" },
                    { 8, "BarManager" },
                    { 9, "CustomerServiceManager" },
                    { 10, "ITAuthority" },
                    { 11, "Custom" }
                });

            migrationBuilder.InsertData(
                table: "tbl_status",
                columns: new[] { "id", "Status" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "InProgress" },
                    { 3, "FollowUp" },
                    { 4, "ClosedWon" },
                    { 5, "ClosedLost" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_call_logs_CallScheduleId",
                table: "tbl_call_logs",
                column: "CallScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_call_schedule_history_CallerId",
                table: "tbl_call_schedule_history",
                column: "CallerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_call_schedule_history_CallStatusId",
                table: "tbl_call_schedule_history",
                column: "CallStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_call_schedule_history_ScheduledById",
                table: "tbl_call_schedule_history",
                column: "ScheduledById");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_call_schedule_history_ScheduledForId",
                table: "tbl_call_schedule_history",
                column: "ScheduledForId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_call_schedule_history_ScheduledWithId",
                table: "tbl_call_schedule_history",
                column: "ScheduledWithId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_kam_users_Email",
                table: "tbl_kam_users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_leads_information_AddedById",
                table: "tbl_leads_information",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_leads_information_AssignedToId",
                table: "tbl_leads_information",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_leads_information_StatusId",
                table: "tbl_leads_information",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_login_Email",
                table: "tbl_master_login",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_poc_contacts_AddedById",
                table: "tbl_poc_contacts",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_poc_contacts_CustomRoleId",
                table: "tbl_poc_contacts",
                column: "CustomRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_poc_contacts_LeadsId",
                table: "tbl_poc_contacts",
                column: "LeadsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_poc_contacts_RoleId",
                table: "tbl_poc_contacts",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardResponse");

            migrationBuilder.DropTable(
                name: "tbl_call_logs");

            migrationBuilder.DropTable(
                name: "tbl_country_time_zones");

            migrationBuilder.DropTable(
                name: "tbl_master_login");

            migrationBuilder.DropTable(
                name: "tbl_call_schedule_history");

            migrationBuilder.DropTable(
                name: "tbl_call_status");

            migrationBuilder.DropTable(
                name: "tbl_poc_contacts");

            migrationBuilder.DropTable(
                name: "tbl_leads_information");

            migrationBuilder.DropTable(
                name: "tbl_poc_custom_roles");

            migrationBuilder.DropTable(
                name: "tbl_poc_roles");

            migrationBuilder.DropTable(
                name: "tbl_kam_users");

            migrationBuilder.DropTable(
                name: "tbl_status");
        }
    }
}
