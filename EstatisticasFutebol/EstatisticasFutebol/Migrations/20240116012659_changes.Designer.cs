﻿// <auto-generated />
using System;
using EstatisticasFutebol.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstatisticasFutebol.Migrations
{
    [DbContext(typeof(UfabcEcContext))]
    [Migration("20240116012659_changes")]
    partial class changes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.AwayProfile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("DefeatOdd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(35.0);

                    b.Property<double>("DrawOdd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(35.0);

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("VictoryOdd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(30.0);

                    b.HasKey("Id");

                    b.ToTable("AwayProfile", (string)null);
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.HomeProfile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("DefeatOdd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(3.0);

                    b.Property<double>("DrawOdd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(35.0);

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("VictoryOdd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(35.0);

                    b.HasKey("Id")
                        .HasName("PK_HomeProfiles");

                    b.HasIndex("Team");

                    b.ToTable("HomeProfile", (string)null);
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.RoundMatches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Away_Score")
                        .HasColumnType("int");

                    b.Property<string>("Away_Team")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<int?>("Home_Score")
                        .HasColumnType("int");

                    b.Property<string>("Home_Team")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Round_Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoundMatches", (string)null);
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.Team", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("AwayProfileId")
                        .HasColumnType("int")
                        .HasColumnName("AwayProfile_Id");

                    b.Property<double?>("ConversionRate")
                        .HasColumnType("float")
                        .HasColumnName("Conversion_Rate");

                    b.Property<int?>("Defeats")
                        .HasColumnType("int");

                    b.Property<int?>("Draws")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsAgainst")
                        .HasColumnType("int")
                        .HasColumnName("Goals_Against");

                    b.Property<int?>("GoalsDifference")
                        .HasColumnType("int")
                        .HasColumnName("Goals_Difference");

                    b.Property<int?>("GoalsFor")
                        .HasColumnType("int")
                        .HasColumnName("Goals_For");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int")
                        .HasColumnName("Goals_Scored");

                    b.Property<string>("GroupLetter")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("Group_Letter")
                        .IsFixedLength();

                    b.Property<int?>("HomeProfileId")
                        .HasColumnType("int")
                        .HasColumnName("HomeProfile_Id");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Matches")
                        .HasColumnType("int");

                    b.Property<int>("NationalRank")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int?>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("AwayProfileId");

                    b.HasIndex("HomeProfileId");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.HomeProfile", b =>
                {
                    b.HasOne("EstatisticasFutebol.Data.Entities.Team", "TeamNavigation")
                        .WithMany("HomeProfiles")
                        .HasForeignKey("Team")
                        .IsRequired()
                        .HasConstraintName("FK_HomeProfile_Team");

                    b.Navigation("TeamNavigation");
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.Team", b =>
                {
                    b.HasOne("EstatisticasFutebol.Data.Entities.AwayProfile", "AwayProfile")
                        .WithMany("Teams")
                        .HasForeignKey("AwayProfileId")
                        .HasConstraintName("FK_Team_AwayProfile");

                    b.HasOne("EstatisticasFutebol.Data.Entities.HomeProfile", "HomeProfile")
                        .WithMany("Teams")
                        .HasForeignKey("HomeProfileId")
                        .HasConstraintName("FK_Team_HomeProfile");

                    b.Navigation("AwayProfile");

                    b.Navigation("HomeProfile");
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.AwayProfile", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.HomeProfile", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("EstatisticasFutebol.Data.Entities.Team", b =>
                {
                    b.Navigation("HomeProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
