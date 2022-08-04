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

            modelBuilder.Entity("LuckyDraw.Models.BarcodeModel", b =>
                {
                    b.Property<int>("BarcodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarcodeCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("BarcodeCount")
                        .HasColumnType("int");

                    b.Property<int>("BarcodeRedemptionLimit")
                        .HasColumnType("int");

                    b.Property<bool>("BarcodeScanned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BarcodeScannedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BarcodeSpinDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("BarcodeUnilimited")
                        .HasColumnType("bit");

                    b.Property<bool>("BarcodeUseSpin")
                        .HasColumnType("bit");

                    b.Property<string>("QRCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("BarcodeId");

                    b.ToTable("BarcodeModels");
                });

            modelBuilder.Entity("LuckyDraw.Models.BulkModel", b =>
                {
                    b.Property<int>("BulkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BulkAutoUpdate")
                        .HasColumnType("bit");

                    b.Property<int>("BulkCount")
                        .HasColumnType("int");

                    b.Property<bool>("BulkOnly")
                        .HasColumnType("bit");

                    b.Property<string>("BulkProgramName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BulkId");

                    b.ToTable("Bulk");
                });

            modelBuilder.Entity("LuckyDraw.Models.CampaignModel", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampaignBarcode")
                        .HasColumnType("int");

                    b.Property<int>("CampaignBulk")
                        .HasColumnType("int");

                    b.Property<string>("CampaignCharset")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CampaignDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CampaignEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CampaignGift")
                        .HasColumnType("int");

                    b.Property<int>("CampaignLength")
                        .HasColumnType("int");

                    b.Property<string>("CampaignNote")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CampaignOwner")
                        .HasColumnType("int");

                    b.Property<string>("CampaignPostfix")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CampaignPrefix")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("CampaignStandalone")
                        .HasColumnType("int");

                    b.Property<DateTime>("CampaignStarDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CampaignUnlimited")
                        .HasColumnType("bit");

                    b.Property<int>("CampaignUsageLimit")
                        .HasColumnType("int");

                    b.HasKey("CampaignId");

                    b.HasIndex("CampaignBarcode");

                    b.HasIndex("CampaignBulk");

                    b.HasIndex("CampaignGift");

                    b.HasIndex("CampaignOwner");

                    b.HasIndex("CampaignStandalone");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("LuckyDraw.Models.CustomerModel", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CustomerBirtday")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CustomerBlock")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerCofirmPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CustomerGiftCode")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CustomerPosition")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("CustomerSentGift")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerTypeBusinees")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CustomerWinDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("CustomerID");

                    b.HasIndex("CustomerGiftCode");

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

                    b.Property<string>("GiftCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("GiftCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("GiftCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GiftDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GiftProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GiftRule")
                        .HasColumnType("int");

                    b.Property<int>("GiftUsed")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("GiftId");

                    b.HasIndex("GiftRule");

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

                    b.Property<int>("RuleAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("RuleEndDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RuleEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RuleMonthly")
                        .HasColumnType("datetime2");

                    b.Property<string>("RuleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RuleProbability")
                        .HasColumnType("int");

                    b.Property<string>("RuleSelectGift")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RuleStartDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RuleStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RuleWeekly")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RullAllDay")
                        .HasColumnType("bit");

                    b.HasKey("RuleId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("LuckyDraw.Models.StandaloneModel", b =>
                {
                    b.Property<int>("StandaloneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("StandaloneApplyAll")
                        .HasColumnType("bit");

                    b.Property<string>("StandaloneCampaignName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StandaloneId");

                    b.ToTable("Standalone");
                });

            modelBuilder.Entity("LuckyDraw.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserCofirmPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserRole");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LuckyDraw.Models.CampaignModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.BarcodeModel", "barcodeModel")
                        .WithMany()
                        .HasForeignKey("CampaignBarcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDraw.Models.BulkModel", "bulkModel")
                        .WithMany()
                        .HasForeignKey("CampaignBulk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDraw.Models.GiftModel", "giftModel")
                        .WithMany()
                        .HasForeignKey("CampaignGift")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDraw.Models.UserModel", "userModel")
                        .WithMany()
                        .HasForeignKey("CampaignOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDraw.Models.StandaloneModel", "standaloneModel")
                        .WithMany()
                        .HasForeignKey("CampaignStandalone")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("barcodeModel");

                    b.Navigation("bulkModel");

                    b.Navigation("giftModel");

                    b.Navigation("standaloneModel");

                    b.Navigation("userModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.CustomerModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.GiftModel", "giftModel")
                        .WithMany()
                        .HasForeignKey("CustomerGiftCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("giftModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.GiftModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.RuleModel", "ruleModel")
                        .WithMany()
                        .HasForeignKey("GiftRule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ruleModel");
                });

            modelBuilder.Entity("LuckyDraw.Models.UserModel", b =>
                {
                    b.HasOne("LuckyDraw.Models.RoleModel", "roleModel")
                        .WithMany()
                        .HasForeignKey("UserRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roleModel");
                });
#pragma warning restore 612, 618
        }
    }
}
