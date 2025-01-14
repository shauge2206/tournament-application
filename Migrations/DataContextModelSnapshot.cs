﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentApp.Data;

#nullable disable

namespace TournamentApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("TournamentApp.Model.PlayerModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            NickName = "Tex",
                            Telephone = "29394003"
                        },
                        new
                        {
                            Id = new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            NickName = "Morty",
                            Telephone = "29303930"
                        },
                        new
                        {
                            Id = new Guid("8fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            NickName = "Pablo",
                            Telephone = "92826262"
                        });
                });

            modelBuilder.Entity("TournamentApp.Model.TeamModel", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            MaxPlayers = 10,
                            MinPlayers = 5,
                            Name = "Alpha Team"
                        },
                        new
                        {
                            TeamId = new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            MaxPlayers = 8,
                            MinPlayers = 3,
                            Name = "Beta Squad"
                        });
                });

            modelBuilder.Entity("TournamentApp.Model.PlayerModel", b =>
                {
                    b.HasOne("TournamentApp.Model.TeamModel", "Team")
                        .WithMany("players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TournamentApp.Model.TeamModel", b =>
                {
                    b.Navigation("players");
                });
#pragma warning restore 612, 618
        }
    }
}
