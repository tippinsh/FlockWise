using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlockWise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<double>(type: "double precision", nullable: false),
                    Alias = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(10,7)", precision: 10, scale: 7, nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric(10,7)", precision: 10, scale: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    EstablishedDateUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Breed = table.Column<string>(type: "text", nullable: true),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flocks_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Flocks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlockNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlockNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlockNotes_Flocks_FlockId",
                        column: x => x.FlockId,
                        principalTable: "Flocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sheep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    Breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Pedigree = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DateOfDeath = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    FeetHealth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NumberOfTeeth = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    LifeStage = table.Column<string>(type: "text", nullable: false),
                    SheepType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sheep_Flocks_FlockId",
                        column: x => x.FlockId,
                        principalTable: "Flocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sheep_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BirthRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SheepId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfBirthUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    WeightBornKgs = table.Column<double>(type: "double precision", nullable: false),
                    BottleFedLamb = table.Column<bool>(type: "boolean", nullable: false),
                    FatherId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotherId = table.Column<Guid>(type: "uuid", nullable: false),
                    BirthComplications = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirthRecords_Sheep_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Sheep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirthRecords_Sheep_MotherId",
                        column: x => x.MotherId,
                        principalTable: "Sheep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirthRecords_Sheep_SheepId",
                        column: x => x.SheepId,
                        principalTable: "Sheep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LambingRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EweId = table.Column<Guid>(type: "uuid", nullable: false),
                    TupId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LambingDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    NumberBorn = table.Column<int>(type: "integer", nullable: true),
                    NumberAlive = table.Column<int>(type: "integer", nullable: true),
                    AssistanceType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LambingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LambingRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lambing_Sheep_Ewe",
                        column: x => x.EweId,
                        principalTable: "Sheep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lambing_Sheep_Tup",
                        column: x => x.TupId,
                        principalTable: "Sheep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SheepId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValueKg = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false),
                    WeighedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightHistory_Sheep_SheepId",
                        column: x => x.SheepId,
                        principalTable: "Sheep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LambingNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LambingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LambingRecordId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LambingNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LambingNotes_LambingRecords_LambingId",
                        column: x => x.LambingId,
                        principalTable: "LambingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LambingNotes_LambingRecords_LambingRecordId",
                        column: x => x.LambingRecordId,
                        principalTable: "LambingRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SheepId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfTreatment = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Complaint = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Medication = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Dose = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Illness = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    VetAdvice = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    LambingRecordId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_LambingRecords_LambingRecordId",
                        column: x => x.LambingRecordId,
                        principalTable: "LambingRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_Sheep_SheepId",
                        column: x => x.SheepId,
                        principalTable: "Sheep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirthRecords_FatherId",
                table: "BirthRecords",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthRecords_MotherId",
                table: "BirthRecords",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthRecords_SheepId",
                table: "BirthRecords",
                column: "SheepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fields_UserId",
                table: "Fields",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlockNotes_FlockId",
                table: "FlockNotes",
                column: "FlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Flocks_FieldId",
                table: "Flocks",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Flocks_UserId",
                table: "Flocks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LambingNotes_LambingId",
                table: "LambingNotes",
                column: "LambingId");

            migrationBuilder.CreateIndex(
                name: "IX_LambingNotes_LambingRecordId",
                table: "LambingNotes",
                column: "LambingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_LambingRecords_EweId",
                table: "LambingRecords",
                column: "EweId");

            migrationBuilder.CreateIndex(
                name: "IX_LambingRecords_LambingDate",
                table: "LambingRecords",
                column: "LambingDate");

            migrationBuilder.CreateIndex(
                name: "IX_LambingRecords_TupId",
                table: "LambingRecords",
                column: "TupId");

            migrationBuilder.CreateIndex(
                name: "IX_LambingRecords_UserId",
                table: "LambingRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheep_FlockId",
                table: "Sheep",
                column: "FlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheep_UserId",
                table: "Sheep",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_LambingRecordId",
                table: "TreatmentRecords",
                column: "LambingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_SheepId",
                table: "TreatmentRecords",
                column: "SheepId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeightHistory_SheepId_WeighedAtUtc",
                table: "WeightHistory",
                columns: new[] { "SheepId", "WeighedAtUtc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthRecords");

            migrationBuilder.DropTable(
                name: "FlockNotes");

            migrationBuilder.DropTable(
                name: "LambingNotes");

            migrationBuilder.DropTable(
                name: "TreatmentRecords");

            migrationBuilder.DropTable(
                name: "WeightHistory");

            migrationBuilder.DropTable(
                name: "LambingRecords");

            migrationBuilder.DropTable(
                name: "Sheep");

            migrationBuilder.DropTable(
                name: "Flocks");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
