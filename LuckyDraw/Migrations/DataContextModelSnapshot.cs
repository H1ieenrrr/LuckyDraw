﻿// <auto-generated />
using System;
using LuckyDraw.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LuckyDraw.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LuckyDraw.Models.BarcodeHistory", b =>
                {
                    b.Property<int>("BarcodeHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarcodeCustomer")
                        .HasColumnType("int");

                    b.Property<string>("BarcodeHistoryOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BarcodeHistoryScanned")
                        .HasColumnType("bit");

                    b.Property<bool>("BarcodeHistoryUsespin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BarcodeHistotyCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BarcodeHistotyScannedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BarcodeHistotySpinDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BarcodeId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BarcodeHistoryId");

                    b.HasIndex("BarcodeCustomer");

                    b.HasIndex("BarcodeId");

                    b.ToTable("BarcodeHistory");
                });

            modelBuilder.Entity("LuckyDraw.Models.BarcodeModel", b =>
                {
                    b.Property<int>("BarcodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BarcodeActive")
                        .HasColumnType("bit");

                    b.Property<int>("BarcodeCharset")
                        .HasColumnType("int");

                    b.Property<string>("BarcodeCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("BarcodeCodeLength")
                        .HasColumnType("int");

                    b.Property<int>("BarcodeCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BarcodeCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BarcodeExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BarcodeRedemptionLimit")
                        .HasColumnType("int");

                    b.Property<int>("BarcodeScanned")
                        .HasColumnType("int");

                    b.Property<DateTime>("BarcodeScannedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("BarcodeUnilimited")
                        .HasColumnType("bit");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("QRCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("BarcodeId");

                    b.HasIndex("CampaignId");

                    b.ToTable("Barcode");
                });

            modelBuilder.Entity("LuckyDraw.Models.CampaignModel", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CampaignApplyAll")
                        .HasColumnType("bit");

                    b.Property<bool>("CampaignAutoUpdate")
                        .HasColumnType("bit");

                    b.Property<string>("CampaignCharset")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CampaignCount")
                        .HasColumnType("int");

                    b.Property<string>("CampaignDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CampaignEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CampaignLength")
                        .HasColumnType("int");

                    b.Property<string>("CampaignName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampaignNote")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("CampaignOnly")
                        .HasColumnType("bit");

                    b.Property<string>("CampaignPostfix")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CampaignPrefix")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CampaignProgramName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CampaignStarDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CampaignUnlimited")
                        .HasColumnType("bit");

                    b.Property<int>("CampaignUsageLimit")
                        .HasColumnType("int");

                    b.HasKey("CampaignId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("LuckyDraw.Models.CustomerModel", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CustomerBirtday")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CustomerBlock")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPassword")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustomerPhone")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CustomerPosition")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CustomerSpin")
                        .HasColumnType("int");

                    b.Property<string>("CustomerTypeBusinees")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("Role");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LuckyDraw.Models.GiftModel", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("GiftActive")
                        .HasColumnType("bit");

                    b.Property<int>("GiftCampaign")
                        .HasColumnType("int");

                    b.Property<string>("GiftCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("GiftCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("GiftCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GiftCustommer")
                        .HasColumnType("int");

                    b.Property<string>("GiftDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GiftProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GiftUsed")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("GiftId");

                    b.HasIndex("GiftCampaign");

                    b.HasIndex("GiftCustommer");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("LuckyDraw.Models.RoleModel", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LuckyDraw.Models.RuleModel", b =>
                {
                    b.Property<int>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("RuleAllDay")
                        .HasColumnType("bit");

                    b.Property<int>("RuleAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("RuleEndDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RuleEndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RuleGiftId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RuleMonthly")
                        .HasColumnType("datetime2");

                    b.Property<string>("RuleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RuleProbability")
                        .HasColumnType("int");

                    b.Property<string>("RuleSelectGift")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RuleStartDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RuleStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RuleWeekly")
                        .HasColumnType("datetime2");

                    b.HasKey("RuleId");

                    b.HasIndex("RuleGiftId")
                        .IsUnique();

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("LuckyDraw.Models.WinnerModel", b =>
                {
                    b.Property<int>("WinnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WinnerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WinnerCustommerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WinnerDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WinnerGift")
                        .HasColumnType("int");

                    b.Property<string>("WinnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WinnerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WinnerProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WinnerStatus")
                        .HasColumnType("bit");

                    b.HasKey("WinnerId");

                    b.HasIndex("WinnerGift");

                    b.ToTable("Winner");
                });

            modelBuilder.Entity("LuckyDraw.Models.BarcodeHistory", b =>
                {
                    b.HasOne("LuckyDraw.Models.CustomerModel", "customerModel")
                        .WithMany()
                        .HasForeignKey("BarcodeCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDraw.Models.BarcodeModel", "barcodeModel")
                        .WithMany()
                        .HasForeignKey("BarcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("barcodeModel");

                    b.Navigation("customerModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.BarcodeModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.CampaignModel", "Campaign")
                        .WithMany("barcodeModels")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("LuckyDraw.Models.CustomerModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.RoleModel", "roleModel")
                        .WithMany()
                        .HasForeignKey("Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roleModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.GiftModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.CampaignModel", "campaignModel")
                        .WithMany("giftModel")
                        .HasForeignKey("GiftCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDraw.Models.CustomerModel", "CustomerModel")
                        .WithMany()
                        .HasForeignKey("GiftCustommer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("campaignModel");

                    b.Navigation("CustomerModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.RuleModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.GiftModel", "giftModel")
                        .WithOne("ruleModel")
                        .HasForeignKey("LuckyDraw.Models.RuleModel", "RuleGiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("giftModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.WinnerModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.GiftModel", "gift")
                        .WithMany()
                        .HasForeignKey("WinnerGift")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("gift");
                });

            modelBuilder.Entity("LuckyDraw.Models.CampaignModel", b =>
                {
                    b.Navigation("barcodeModels");

                    b.Navigation("giftModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.GiftModel", b =>
                {
                    b.Navigation("ruleModel");
                });
#pragma warning restore 612, 618
        }
    }
}
