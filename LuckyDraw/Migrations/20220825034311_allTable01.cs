using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LuckyDraw.Migrations
{
    public partial class allTable01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barcode",
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
                    table.PrimaryKey("PK_Barcode", x => x.BarcodeId);
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
                    CustomerBlock = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CustomerPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
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
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.GiftId);
                    table.ForeignKey(
                        name: "FK_Gifts_Customers_GiftCustommer",
                        column: x => x.GiftCustommer,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    CampaignNote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CampaignGift = table.Column<int>(type: "int", nullable: false),
                    CampaignBarcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                    table.ForeignKey(
                        name: "FK_Campaigns_Barcode_CampaignBarcode",
                        column: x => x.CampaignBarcode,
                        principalTable: "Barcode",
                        principalColumn: "BarcodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_Gifts_CampaignGift",
                        column: x => x.CampaignGift,
                        principalTable: "Gifts",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Rules_Gifts_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Gifts",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Winner",
                columns: table => new
                {
                    WinnerCustommerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerGift = table.Column<int>(type: "int", nullable: false),
                    WinnerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winner", x => x.WinnerCustommerId);
                    table.ForeignKey(
                        name: "FK_Winner_Gifts_WinnerGift",
                        column: x => x.WinnerGift,
                        principalTable: "Gifts",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignBarcode",
                table: "Campaigns",
                column: "CampaignBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignGift",
                table: "Campaigns",
                column: "CampaignGift",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Role",
                table: "Customers",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_GiftCustommer",
                table: "Gifts",
                column: "GiftCustommer");

            migrationBuilder.CreateIndex(
                name: "IX_Winner_WinnerGift",
                table: "Winner",
                column: "WinnerGift");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Winner");

            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
