﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MissionApi.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace missioncrud.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MissionApi.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MissionAvailability")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MissionDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MissionDocuments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MissionImages")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MissionOrganisationDetail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MissionOrganisationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MissionSkillId")
                        .HasColumnType("integer");

                    b.Property<int>("MissionThemeId")
                        .HasColumnType("integer");

                    b.Property<string>("MissionTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MissionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MissionVideoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDeadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TotalSheets")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MissionThemeId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("MissionApi.Models.MissionTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThemeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MissionThemes");
                });

            modelBuilder.Entity("MissionApi.Models.Mission", b =>
                {
                    b.HasOne("MissionApi.Models.MissionTheme", "MissionTheme")
                        .WithMany("Missions")
                        .HasForeignKey("MissionThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MissionTheme");
                });

            modelBuilder.Entity("MissionApi.Models.MissionTheme", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}
