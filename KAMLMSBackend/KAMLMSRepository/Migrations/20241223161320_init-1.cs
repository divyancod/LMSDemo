using System;
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
                name: "CustomRoleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRoleEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginEntities",
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
                    table.PrimaryKey("PK_LoginEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagersEntity",
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
                    table.PrimaryKey("PK_ManagersEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadsEntity",
                columns: table => new
                {
                    ResturantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResturantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResturantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadsEntity", x => x.ResturantId);
                    table.ForeignKey(
                        name: "FK_LeadsEntity_ManagersEntity_AddedById",
                        column: x => x.AddedById,
                        principalTable: "ManagersEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeadsEntity_ManagersEntity_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "ManagersEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadsEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ContactEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEntity_CustomRoleEntity_CustomRoleId",
                        column: x => x.CustomRoleId,
                        principalTable: "CustomRoleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactEntity_LeadsEntity_LeadsEntityId",
                        column: x => x.LeadsEntityId,
                        principalTable: "LeadsEntity",
                        principalColumn: "ResturantId");
                    table.ForeignKey(
                        name: "FK_ContactEntity_ManagersEntity_AddedById",
                        column: x => x.AddedById,
                        principalTable: "ManagersEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactEntity_RolesEntity_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RolesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RolesEntity",
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
                    { 10, "ITAuthority" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactEntity_AddedById",
                table: "ContactEntity",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactEntity_CustomRoleId",
                table: "ContactEntity",
                column: "CustomRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactEntity_LeadsEntityId",
                table: "ContactEntity",
                column: "LeadsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactEntity_RoleId",
                table: "ContactEntity",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadsEntity_AddedById",
                table: "LeadsEntity",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeadsEntity_AssignedToId",
                table: "LeadsEntity",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginEntities_Email",
                table: "LoginEntities",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagersEntity_Email",
                table: "ManagersEntity",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactEntity");

            migrationBuilder.DropTable(
                name: "LoginEntities");

            migrationBuilder.DropTable(
                name: "CustomRoleEntity");

            migrationBuilder.DropTable(
                name: "LeadsEntity");

            migrationBuilder.DropTable(
                name: "RolesEntity");

            migrationBuilder.DropTable(
                name: "ManagersEntity");
        }
    }
}
