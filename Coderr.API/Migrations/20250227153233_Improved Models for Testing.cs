using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coderr.API.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedModelsforTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferDetails_Offers_OfferId",
                table: "OfferDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserProfiles_UserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OfferDetails_detailsid",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "OfferId",
                table: "OfferDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferDetails_Offers_OfferId",
                table: "OfferDetails",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_UserProfiles_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OfferDetails_detailsid",
                table: "Orders",
                column: "detailsid",
                principalTable: "OfferDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferDetails_Offers_OfferId",
                table: "OfferDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserProfiles_UserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OfferDetails_detailsid",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OfferId",
                table: "OfferDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferDetails_Offers_OfferId",
                table: "OfferDetails",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_UserProfiles_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OfferDetails_detailsid",
                table: "Orders",
                column: "detailsid",
                principalTable: "OfferDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
