using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LuckyDraw.Migrations
{
    public partial class allTable01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignProgramName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CampaignCount = table.Column<int>(type: "int", nullable: false),
                    CampaignAutoUpdate = table.Column<bool>(type: "bit", nullable: false),
                    CampaignOnly = table.Column<bool>(type: "bit", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignApplyAll = table.Column<bool>(type: "bit", nullable: false),
                    CampaignDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CampaignUsageLimit = table.Column<int>(type: "int", nullable: false),
                    CampaignUnlimited = table.Column<bool>(type: "bit", nullable: false),
                    CampaignCharset = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CampaignLength = table.Column<int>(type: "int", nullable: false),
                    CampaignPrefix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CampaignPostfix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CampaignStarDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignNote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
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
                name: "Barcode",
                columns: table => new
                {
                    BarcodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BarcodeCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    QRCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BarcodeCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeCount = table.Column<int>(type: "int", nullable: false),
                    BarcodeCharset = table.Column<int>(type: "int", nullable: false),
                    BarcodeCodeLength = table.Column<int>(type: "int", nullable: false),
                    BarcodeUnilimited = table.Column<bool>(type: "bit", nullable: false),
                    BarcodeRedemptionLimit = table.Column<int>(type: "int", nullable: false),
                    BarcodeScannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    BarcodeScanned = table.Column<int>(type: "int", nullable: false),
                    BarcodeActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.BarcodeId);
                    table.ForeignKey(
                        name: "FK_Barcode_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerBirtday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerPosition = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CustomerTypeBusinees = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CustomerBlock = table.Column<bool>(type: "bit", nullable: false),
                    CustomerSpin = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CustomerPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Roles_Role",
                        column: x => x.Role,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarcodeHistory",
                columns: table => new
                {
                    BarcodeHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarcodeCustomer = table.Column<int>(type: "int", nullable: false),
                    BarcodeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarcodeHistotyCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeHistotyScannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeHistotySpinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarcodeHistoryOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarcodeHistoryScanned = table.Column<bool>(type: "bit", nullable: false),
                    BarcodeHistoryUsespin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeHistory", x => x.BarcodeHistoryId);
                    table.ForeignKey(
                        name: "FK_BarcodeHistory_Barcode_BarcodeId",
                        column: x => x.BarcodeId,
                        principalTable: "Barcode",
                        principalColumn: "BarcodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarcodeHistory_Customers_BarcodeCustomer",
                        column: x => x.BarcodeCustomer,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
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
                    GiftUsed = table.Column<int>(type: "int", nullable: false),
                    GiftCustommer = table.Column<int>(type: "int", nullable: false),
                    GiftCampaign = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.GiftId);
                    table.ForeignKey(
                        name: "FK_Gifts_Campaigns_GiftCampaign",
                        column: x => x.GiftCampaign,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gifts_Customers_GiftCustommer",
                        column: x => x.GiftCustommer,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RuleSelectGift = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RuleAmount = table.Column<int>(type: "int", nullable: false),
                    RuleStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleAllDay = table.Column<bool>(type: "bit", nullable: false),
                    RuleProbability = table.Column<int>(type: "int", nullable: false),
                    RuleMonthly = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleWeekly = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleStartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleEndDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuleGiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.RuleId);
                    table.ForeignKey(
                        name: "FK_Rules_Gifts_RuleGiftId",
                        column: x => x.RuleGiftId,
                        principalTable: "Gifts",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Winner",
                columns: table => new
                {
                    WinnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerCustommerId = table.Column<int>(type: "int", nullable: false),
                    WinnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerGift = table.Column<int>(type: "int", nullable: false),
                    WinnerProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winner", x => x.WinnerId);
                    table.ForeignKey(
                        name: "FK_Winner_Gifts_WinnerGift",
                        column: x => x.WinnerGift,
                        principalTable: "Gifts",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_CampaignId",
                table: "Barcode",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_BarcodeHistory_BarcodeCustomer",
                table: "BarcodeHistory",
                column: "BarcodeCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_BarcodeHistory_BarcodeId",
                table: "BarcodeHistory",
                column: "BarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Role",
                table: "Customers",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_GiftCampaign",
                table: "Gifts",
                column: "GiftCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_GiftCustommer",
                table: "Gifts",
                column: "GiftCustommer");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_RuleGiftId",
                table: "Rules",
                column: "RuleGiftId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Winner_WinnerGift",
                table: "Winner",
                column: "WinnerGift");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarcodeHistory");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Winner");

            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
