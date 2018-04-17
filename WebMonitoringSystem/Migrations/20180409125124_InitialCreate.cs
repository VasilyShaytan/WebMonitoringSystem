using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebMonitoringSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicParameter",
                columns: table => new
                {
                    BasicParameterID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Acronym = table.Column<string>(nullable: true),
                    DataRange = table.Column<string>(nullable: true),
                    DataSource = table.Column<string>(nullable: true),
                    PGL = table.Column<int>(nullable: false),
                    PGN = table.Column<int>(nullable: false),
                    SPNName = table.Column<string>(nullable: true),
                    SPNNameRu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicParameter", x => x.BasicParameterID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserLogin = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    UserPhone = table.Column<string>(nullable: true),
                    UserRole = table.Column<int>(nullable: false),
                    UserSurname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Mark = table.Column<string>(nullable: true),
                    ModelType = table.Column<string>(nullable: true),
                    OverallDimensions = table.Column<string>(nullable: true),
                    UsefulVolume = table.Column<int>(nullable: false),
                    VehicleType = table.Column<string>(nullable: true),
                    YearIssue = table.Column<int>(nullable: false),
                    СarryingСapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleGroup",
                columns: table => new
                {
                    VehicleGroupID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    VehicleGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleGroup", x => x.VehicleGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    ParameterID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BasicParameterID = table.Column<int>(nullable: false),
                    BasicParameterTimeValue = table.Column<DateTime>(nullable: false),
                    BasicParameterValue = table.Column<int>(nullable: false),
                    VehicleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.ParameterID);
                    table.ForeignKey(
                        name: "FK_Parameter_BasicParameter_BasicParameterID",
                        column: x => x.BasicParameterID,
                        principalTable: "BasicParameter",
                        principalColumn: "BasicParameterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToRole",
                columns: table => new
                {
                    UserToRoleID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRole", x => x.UserToRoleID);
                    table.ForeignKey(
                        name: "FK_UserToRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToRole_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CoordinateLatitude = table.Column<double>(nullable: false),
                    CoordinateLongitude = table.Column<double>(nullable: false),
                    VehicleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Route_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleToVehicleGroup",
                columns: table => new
                {
                    VehicleToVehicleGroupID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    VehicleGroupID = table.Column<int>(nullable: false),
                    VehicleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleToVehicleGroup", x => x.VehicleToVehicleGroupID);
                    table.ForeignKey(
                        name: "FK_VehicleToVehicleGroup_VehicleGroup_VehicleGroupID",
                        column: x => x.VehicleGroupID,
                        principalTable: "VehicleGroup",
                        principalColumn: "VehicleGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleToVehicleGroup_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_BasicParameterID",
                table: "Parameter",
                column: "BasicParameterID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_VehicleID",
                table: "Route",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRole_RoleID",
                table: "UserToRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRole_UserID",
                table: "UserToRole",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleToVehicleGroup_VehicleGroupID",
                table: "VehicleToVehicleGroup",
                column: "VehicleGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleToVehicleGroup_VehicleID",
                table: "VehicleToVehicleGroup",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "UserToRole");

            migrationBuilder.DropTable(
                name: "VehicleToVehicleGroup");

            migrationBuilder.DropTable(
                name: "BasicParameter");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VehicleGroup");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
