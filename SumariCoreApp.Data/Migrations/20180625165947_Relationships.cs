﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SumariCoreApp.Data.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sumarais_Battles_BattleId",
                table: "Sumarais");

            migrationBuilder.DropIndex(
                name: "IX_Sumarais_BattleId",
                table: "Sumarais");

            migrationBuilder.CreateTable(
                name: "SamuraiBattle",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiBattle", x => new { x.SamuraiId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_SamuraiBattle_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraiBattle_Sumarais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Sumarais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentity_Sumarais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Sumarais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_BattleId",
                table: "SamuraiBattle",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SamuraiBattle");

            migrationBuilder.DropTable(
                name: "SecretIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Sumarais_BattleId",
                table: "Sumarais",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sumarais_Battles_BattleId",
                table: "Sumarais",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}