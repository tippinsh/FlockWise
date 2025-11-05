using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlockWise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFarmEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Users_UserId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Flocks_Users_UserId",
                table: "Flocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheep_Users_UserId",
                table: "Sheep");

            migrationBuilder.RenameColumn(
                name: "LambingDate",
                table: "LambingRecords",
                newName: "LambingDateUtc");

            migrationBuilder.RenameIndex(
                name: "IX_LambingRecords_LambingDate",
                table: "LambingRecords",
                newName: "IX_LambingRecords_LambingDateUtc");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "LambingNotes",
                newName: "LastUpdatedUtc");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "FlockNotes",
                newName: "UpdatedAtUtc");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WeightHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TreatmentRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sheep",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Sheep",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EidTag",
                table: "Sheep",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "Sheep",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MotheringAbility",
                table: "Sheep",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueIdentificationNumber",
                table: "Sheep",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAtUtc",
                table: "Sheep",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "Sheep",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LambingNotes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Flocks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "Flocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAtUtc",
                table: "Flocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "Flocks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FlockNotes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Fields",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "Fields",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAtUtc",
                table: "BirthRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAtUtc",
                table: "BirthRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "BirthRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlockMark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightHistory_UserId",
                table: "WeightHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FarmId",
                table: "Users",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_UserId",
                table: "TreatmentRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheep_FarmId",
                table: "Sheep",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheep_UpdatedByUserId",
                table: "Sheep",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LambingNotes_UserId",
                table: "LambingNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flocks_FarmId",
                table: "Flocks",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Flocks_UpdatedByUserId",
                table: "Flocks",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlockNotes_UserId",
                table: "FlockNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FarmId",
                table: "Fields",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthRecords_UpdatedByUserId",
                table: "BirthRecords",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthRecords_Users_UpdatedByUserId",
                table: "BirthRecords",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Farms_FarmId",
                table: "Fields",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Users_UserId",
                table: "Fields",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlockNotes_Users_UserId",
                table: "FlockNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flocks_Farms_FarmId",
                table: "Flocks",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flocks_Users_UpdatedByUserId",
                table: "Flocks",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Flocks_Users_UserId",
                table: "Flocks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LambingNotes_Users_UserId",
                table: "LambingNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheep_Farms_FarmId",
                table: "Sheep",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheep_Users_UpdatedByUserId",
                table: "Sheep",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheep_Users_UserId",
                table: "Sheep",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Users_UserId",
                table: "TreatmentRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Farms_FarmId",
                table: "Users",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightHistory_Users_UserId",
                table: "WeightHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthRecords_Users_UpdatedByUserId",
                table: "BirthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Farms_FarmId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Users_UserId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_FlockNotes_Users_UserId",
                table: "FlockNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Flocks_Farms_FarmId",
                table: "Flocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Flocks_Users_UpdatedByUserId",
                table: "Flocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Flocks_Users_UserId",
                table: "Flocks");

            migrationBuilder.DropForeignKey(
                name: "FK_LambingNotes_Users_UserId",
                table: "LambingNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheep_Farms_FarmId",
                table: "Sheep");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheep_Users_UpdatedByUserId",
                table: "Sheep");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheep_Users_UserId",
                table: "Sheep");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_Users_UserId",
                table: "TreatmentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Farms_FarmId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightHistory_Users_UserId",
                table: "WeightHistory");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_WeightHistory_UserId",
                table: "WeightHistory");

            migrationBuilder.DropIndex(
                name: "IX_Users_FarmId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentRecords_UserId",
                table: "TreatmentRecords");

            migrationBuilder.DropIndex(
                name: "IX_Sheep_FarmId",
                table: "Sheep");

            migrationBuilder.DropIndex(
                name: "IX_Sheep_UpdatedByUserId",
                table: "Sheep");

            migrationBuilder.DropIndex(
                name: "IX_LambingNotes_UserId",
                table: "LambingNotes");

            migrationBuilder.DropIndex(
                name: "IX_Flocks_FarmId",
                table: "Flocks");

            migrationBuilder.DropIndex(
                name: "IX_Flocks_UpdatedByUserId",
                table: "Flocks");

            migrationBuilder.DropIndex(
                name: "IX_FlockNotes_UserId",
                table: "FlockNotes");

            migrationBuilder.DropIndex(
                name: "IX_Fields_FarmId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_BirthRecords_UpdatedByUserId",
                table: "BirthRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WeightHistory");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TreatmentRecords");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "EidTag",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "MotheringAbility",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "UniqueIdentificationNumber",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LambingNotes");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Flocks");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Flocks");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Flocks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlockNotes");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "BirthRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "BirthRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "BirthRecords");

            migrationBuilder.RenameColumn(
                name: "LambingDateUtc",
                table: "LambingRecords",
                newName: "LambingDate");

            migrationBuilder.RenameIndex(
                name: "IX_LambingRecords_LambingDateUtc",
                table: "LambingRecords",
                newName: "IX_LambingRecords_LambingDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedUtc",
                table: "LambingNotes",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                table: "FlockNotes",
                newName: "LastModified");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sheep",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Flocks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Fields",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Users_UserId",
                table: "Fields",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flocks_Users_UserId",
                table: "Flocks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheep_Users_UserId",
                table: "Sheep",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
