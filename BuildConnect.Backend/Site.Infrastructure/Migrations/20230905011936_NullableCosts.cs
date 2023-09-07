using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullableCosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_EquipmentCosts_EquipmentCostId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_ManPowerCosts_ManPowerCostId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_MaterialCosts_MaterialCostId",
                table: "WorkItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialCostId",
                table: "WorkItems",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManPowerCostId",
                table: "WorkItems",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentCostId",
                table: "WorkItems",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_EquipmentCosts_EquipmentCostId",
                table: "WorkItems",
                column: "EquipmentCostId",
                principalTable: "EquipmentCosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_ManPowerCosts_ManPowerCostId",
                table: "WorkItems",
                column: "ManPowerCostId",
                principalTable: "ManPowerCosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_MaterialCosts_MaterialCostId",
                table: "WorkItems",
                column: "MaterialCostId",
                principalTable: "MaterialCosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_EquipmentCosts_EquipmentCostId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_ManPowerCosts_ManPowerCostId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_MaterialCosts_MaterialCostId",
                table: "WorkItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialCostId",
                table: "WorkItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ManPowerCostId",
                table: "WorkItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentCostId",
                table: "WorkItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_EquipmentCosts_EquipmentCostId",
                table: "WorkItems",
                column: "EquipmentCostId",
                principalTable: "EquipmentCosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_ManPowerCosts_ManPowerCostId",
                table: "WorkItems",
                column: "ManPowerCostId",
                principalTable: "ManPowerCosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_MaterialCosts_MaterialCostId",
                table: "WorkItems",
                column: "MaterialCostId",
                principalTable: "MaterialCosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
