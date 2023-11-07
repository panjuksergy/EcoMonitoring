﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SparkSwim.GoodsService;

#nullable disable

namespace EcoMonitoringService.Migrations
{
    [DbContext(typeof(EcoDbContext))]
    partial class EcoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SparkSwim.GoodsService.Goods.Models.EcoRecord", b =>
                {
                    b.Property<Guid>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Ammonia")
                        .HasColumnType("float");

                    b.Property<double>("CarbonDioxide")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Formaldehyde")
                        .HasColumnType("float");

                    b.Property<double>("HydrogenFluoride")
                        .HasColumnType("float");

                    b.Property<Guid>("MonitoringSingleStatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("NitrogenDioxide")
                        .HasColumnType("float");

                    b.Property<double>("SulfurDioxide")
                        .HasColumnType("float");

                    b.Property<double>("SuspendedSolids")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecordId");

                    b.ToTable("EcoRecords");
                });

            modelBuilder.Entity("SparkSwim.GoodsService.Goods.Models.MonitoringSingleStat", b =>
                {
                    b.Property<Guid>("MonitoringSingleStatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmmoniaStat")
                        .HasColumnType("float");

                    b.Property<double>("CarbonDioxideStat")
                        .HasColumnType("float");

                    b.Property<double>("FormaldehydeStat")
                        .HasColumnType("float");

                    b.Property<double>("HydrogenFluorideStat")
                        .HasColumnType("float");

                    b.Property<double>("NitrogenDioxideStat")
                        .HasColumnType("float");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("SulfurDioxideStat")
                        .HasColumnType("float");

                    b.Property<double>("SuspendedSolidsStat")
                        .HasColumnType("float");

                    b.Property<double>("TotalNonCancerRisk")
                        .HasColumnType("float");

                    b.HasKey("MonitoringSingleStatId");

                    b.HasIndex("RecordId")
                        .IsUnique();

                    b.ToTable("MonitoringSingleStats");
                });

            modelBuilder.Entity("SparkSwim.GoodsService.Goods.Models.MonitoringSingleStat", b =>
                {
                    b.HasOne("SparkSwim.GoodsService.Goods.Models.EcoRecord", "EcoRecord")
                        .WithOne("MonitoringSingleStat")
                        .HasForeignKey("SparkSwim.GoodsService.Goods.Models.MonitoringSingleStat", "RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EcoRecord");
                });

            modelBuilder.Entity("SparkSwim.GoodsService.Goods.Models.EcoRecord", b =>
                {
                    b.Navigation("MonitoringSingleStat")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}