﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WifiUserRecorder.DataAccess;

namespace WifiUserRecorder.Migrations
{
    [DbContext(typeof(RecordDBContext))]
    partial class RecordDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("WifiUserRecorder.Models.Equipment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mac")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Mac", "Name");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("WifiUserRecorder.Models.RecordRelation", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EquipmentID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WifiRecordID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentID");

                    b.HasIndex("WifiRecordID");

                    b.ToTable("RecordRelations");
                });

            modelBuilder.Entity("WifiUserRecorder.Models.WifiRecord", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("DateTime");

                    b.ToTable("WifiRecords");
                });

            modelBuilder.Entity("WifiUserRecorder.Models.RecordRelation", b =>
                {
                    b.HasOne("WifiUserRecorder.Models.Equipment", "Equipment")
                        .WithMany("RecordRelations")
                        .HasForeignKey("EquipmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WifiUserRecorder.Models.WifiRecord", "WifiRecord")
                        .WithMany("RecordRelations")
                        .HasForeignKey("WifiRecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
