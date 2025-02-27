using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coderr.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_UserProfiles_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_UserProfiles_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revisions = table.Column<int>(type: "int", nullable: false),
                    DeliveryTimeInDays = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferDetails_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OfferDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revisions = table.Column<int>(type: "int", nullable: false),
                    DeliveryTimeInDays = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OfferDetails_OfferDetailsId",
                        column: x => x.OfferDetailsId,
                        principalTable: "OfferDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferDetails_OfferId",
                table: "OfferDetails",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BusinessUserId",
                table: "Orders",
                column: "BusinessUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OfferDetailsId",
                table: "Orders",
                column: "OfferDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BusinessUserId",
                table: "Reviews",
                column: "BusinessUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "OfferDetails");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
