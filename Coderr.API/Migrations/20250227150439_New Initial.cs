using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coderr.API.Migrations
{
    /// <inheritdoc />
    public partial class NewInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    working_hours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offers_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reviews_UserProfiles_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Reviews_UserProfiles_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "UserProfiles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OfferDetails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    revisions = table.Column<int>(type: "int", nullable: false),
                    delivery_time_in_days = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer_type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OfferDetails_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    detailsid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    revisions = table.Column<int>(type: "int", nullable: false),
                    delivery_time_in_days = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_OfferDetails_detailsid",
                        column: x => x.detailsid,
                        principalTable: "OfferDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "id");
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
                name: "IX_Orders_detailsid",
                table: "Orders",
                column: "detailsid");

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
