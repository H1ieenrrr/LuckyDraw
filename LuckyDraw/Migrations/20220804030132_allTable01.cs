using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LuckyDraw.Migrations
{
    public partial class allTable01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarcodeModels",
                columns: table => new
                {
                    BarcodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarcodeCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    QRCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BarcodeCount = table.Column<int>(type: "int", nullable: false),
                    BarcodeUnilimited = table.Column<bool>(type: "bit", nullable: false),
                    BarcodeRedemptionLimit = table.Column<int>(type: "int", nullable: false),
                    BarcodeSpinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeScannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeScanned = table.Column<bool>(type: "bit", nullable: false),
                    BarcodeUseSpin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeModels", x => x.BarcodeId);
                });

            migrationBuilder.CreateTable(
                name: "Bulk",
                columns: table => new
                {
                    BulkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BulkProgramName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BulkCount = table.Column<int>(type: "int", nullable: false),
                    BulkAutoUpdate = table.Column<bool>(type: "bit", nullable: false),
                    BulkOnly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulk", x => x.BulkId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RuleSelectGift = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RuleAmount = table.Column<int>(type: "int", nullable: false),
                    RuleStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RullAllDay = table.Column<bool>(type: "bit", nullable: false),
                    RuleProbability = table.Column<int>(type: "int", nullable: false),
                    RuleMonthly = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleWeekly = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleStartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleEndDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.RuleId);
                });

            migrationBuilder.CreateTable(
                name: "Standalone",
                columns: table => new
                {
                    StandaloneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandaloneCampaignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandaloneApplyAll = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standalone", x => x.StandaloneId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    UserPhone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserCofirmPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_UserRole",
                        column: x => x.UserRole,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    GiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    GiftProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GiftDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GiftCount = table.Column<int>(type: "int", nullable: false),
                    GiftCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiftActive = table.Column<bool>(type: "bit", nullable: false),
                    GiftRule = table.Column<int>(type: "int", nullable: false),
                    GiftUsed = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.GiftId);
                    table.ForeignKey(
                        name: "FK_Gifts_Rules_GiftRule",
                        column: x => x.GiftRule,
                        principalTable: "Rules",
                        principalColumn: "RuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignBulk = table.Column<int>(type: "int", nullable: false),
                    CampaignStandalone = table.Column<int>(type: "int", nullable: false),
                    CampaignDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CampaignUsageLimit = table.Column<int>(type: "int", nullable: false),
                    CampaignUnlimited = table.Column<bool>(type: "bit", nullable: false),
                    CampaignCharset = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CampaignLength = table.Column<int>(type: "int", nullable: false),
                    CampaignPrefix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CampaignPostfix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CampaignStarDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignNote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CampaignGift = table.Column<int>(type: "int", nullable: false),
                    CampaignOwner = table.Column<int>(type: "int", nullable: false),
                    CampaignBarcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                    table.ForeignKey(
                        name: "FK_Campaigns_BarcodeModels_CampaignBarcode",
                        column: x => x.CampaignBarcode,
                        principalTable: "BarcodeModels",
                        principalColumn: "BarcodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_Bulk_CampaignBulk",
                        column: x => x.CampaignBulk,
                        principalTable: "Bulk",
                        principalColumn: "BulkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_Gifts_CampaignGift",
                        column: x => x.CampaignGift,
                        principalTable: "Gifts",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_Standalone_CampaignStandalone",
                        column: x => x.CampaignStandalone,
                        principalTable: "Standalone",
                        principalColumn: "StandaloneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_CampaignOwner",
                        column: x => x.CampaignOwner,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerPhone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerBirtday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerPosition = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CustomerTypeBusinees = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CustomerWinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerBlock = table.Column<bool>(type: "bit", nullable: false),
                    CustomerSentGift = table.Column<bool>(type: "bit", nullable: false),
                    CustomerPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CustomerCofirmPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CustomerGiftCode = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Gifts_CustomerGiftCode",
                        column: x => x.CustomerGiftCode,
                        principalTable: "Gifts",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignBarcode",
                table: "Campaigns",
                column: "CampaignBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignBulk",
                table: "Campaigns",
                column: "CampaignBulk");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignGift",
                table: "Campaigns",
                column: "CampaignGift");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignOwner",
                table: "Campaigns",
                column: "CampaignOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignStandalone",
                table: "Campaigns",
                column: "CampaignStandalone");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerGiftCode",
                table: "Customers",
                column: "CustomerGiftCode");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_GiftRule",
                table: "Gifts",
                column: "GiftRule");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRole",
                table: "Users",
                column: "UserRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "BarcodeModels");

            migrationBuilder.DropTable(
                name: "Bulk");

            migrationBuilder.DropTable(
                name: "Standalone");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Rules");
        }
    }
}
