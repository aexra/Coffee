﻿// <auto-generated />
using System;
using Coffee.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coffee.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240420103748_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Coffee.Models.CompletedMeeting", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("CancellerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<short>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagesBlobbed")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Success")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("User1Id")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("User2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CancellerId");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("CompletedMeetings");
                });

            modelBuilder.Entity("Coffee.Models.FutureMeeting", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<short>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("User1Id")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("User2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("FutureMeetings");
                });

            modelBuilder.Entity("Coffee.Models.Image", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BytesString")
                        .HasColumnType("TEXT");

                    b.Property<ulong?>("CompletedMeetingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompletedMeetingId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Coffee.Models.Room", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("User1Id")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("User2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Coffee.Models.Theme", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Coffee.Models.User", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("AvatarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Coffee")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("HiredSince")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hobbies")
                        .HasColumnType("TEXT");

                    b.Property<uint>("MeetingsCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pets")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telegram")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vk")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Coffee.Models.CompletedMeeting", b =>
                {
                    b.HasOne("Coffee.Models.User", "Canceller")
                        .WithMany()
                        .HasForeignKey("CancellerId");

                    b.HasOne("Coffee.Models.User", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id");

                    b.HasOne("Coffee.Models.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id");

                    b.Navigation("Canceller");

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("Coffee.Models.FutureMeeting", b =>
                {
                    b.HasOne("Coffee.Models.User", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id");

                    b.HasOne("Coffee.Models.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id");

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("Coffee.Models.Image", b =>
                {
                    b.HasOne("Coffee.Models.CompletedMeeting", null)
                        .WithMany("Images")
                        .HasForeignKey("CompletedMeetingId");
                });

            modelBuilder.Entity("Coffee.Models.Room", b =>
                {
                    b.HasOne("Coffee.Models.User", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id");

                    b.HasOne("Coffee.Models.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id");

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("Coffee.Models.User", b =>
                {
                    b.HasOne("Coffee.Models.Image", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("Coffee.Models.CompletedMeeting", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
