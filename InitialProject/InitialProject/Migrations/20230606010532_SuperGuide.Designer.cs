﻿// <auto-generated />
using System;
using InitialProject.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InitialProject.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20230606010532_SuperGuide")]
    partial class SuperGuide
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("ComplexTourRequestUser", b =>
                {
                    b.Property<int>("ComplexTourRequestsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuidesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ComplexTourRequestsId", "GuidesId");

                    b.HasIndex("GuidesId");

                    b.ToTable("ComplexTourRequestUser");
                });

            modelBuilder.Entity("InitialProject.Model.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CancellationDeadline")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GuestLimit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinimumReservationDays")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("locationID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ownerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("locationID");

                    b.HasIndex("ownerId");

                    b.ToTable("Accommodation");
                });

            modelBuilder.Entity("InitialProject.Model.AccommodationReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccommodationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BegginingDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("GuestId");

                    b.ToTable("AccommodationReservation");
                });

            modelBuilder.Entity("InitialProject.Model.AccommodationReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccommodationReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Correctness")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tidiness")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationReservationId");

                    b.ToTable("AccommodationReview");
                });

            modelBuilder.Entity("InitialProject.Model.ComplexTourRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ComplexTourRequest");
                });

            modelBuilder.Entity("InitialProject.Model.GuestReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Obedience")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tidiness")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("GuestReview");
                });

            modelBuilder.Entity("InitialProject.Model.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("TourId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("InitialProject.Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("InitialProject.Model.RenovationSuggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RenovationRating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("RenovationSuggestion");
                });

            modelBuilder.Entity("InitialProject.Model.ReservationReschedulingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccommodationReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Achievable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NewEndingDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NewStartingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WasNotified")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationReservationId");

                    b.ToTable("ReservationReschedulingRequest");
                });

            modelBuilder.Entity("InitialProject.Model.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuestLimit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("guideID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("locationID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("guideID");

                    b.HasIndex("locationID");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("InitialProject.Model.TourKeyPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Reached")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("tourID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("tourID");

                    b.ToTable("TourKeyPoint");
                });

            modelBuilder.Entity("InitialProject.Model.TourRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComplexTourRequestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LowerDateLimit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SelectedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpperDateLimit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ComplexTourRequestId");

                    b.HasIndex("LocationId");

                    b.ToTable("TourRequest");
                });

            modelBuilder.Entity("InitialProject.Model.TourReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingGuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourKeyPointId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookingGuestId");

                    b.HasIndex("TourId");

                    b.HasIndex("TourKeyPointId");

                    b.HasIndex("VoucherId");

                    b.ToTable("TourReservation");
                });

            modelBuilder.Entity("InitialProject.Model.TourReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmusementScore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GuideKnowledge")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuideLanguage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TourReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Valid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TourReservationId");

                    b.ToTable("TourReview");
                });

            modelBuilder.Entity("InitialProject.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BonusPoints")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("SuperTitle")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SuperTitleValidTill")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("InitialProject.Model.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ObtainedReason")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("ComplexTourRequestUser", b =>
                {
                    b.HasOne("InitialProject.Model.ComplexTourRequest", null)
                        .WithMany()
                        .HasForeignKey("ComplexTourRequestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InitialProject.Model.User", null)
                        .WithMany()
                        .HasForeignKey("GuidesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InitialProject.Model.Accommodation", b =>
                {
                    b.HasOne("InitialProject.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("locationID");

                    b.HasOne("InitialProject.Model.User", "Owner")
                        .WithMany()
                        .HasForeignKey("ownerId");

                    b.Navigation("Location");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("InitialProject.Model.AccommodationReservation", b =>
                {
                    b.HasOne("InitialProject.Model.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InitialProject.Model.User", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("InitialProject.Model.AccommodationReview", b =>
                {
                    b.HasOne("InitialProject.Model.AccommodationReservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("AccommodationReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("InitialProject.Model.GuestReview", b =>
                {
                    b.HasOne("InitialProject.Model.AccommodationReservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("InitialProject.Model.Image", b =>
                {
                    b.HasOne("InitialProject.Model.Accommodation", "Accommodation")
                        .WithMany("Images")
                        .HasForeignKey("AccommodationId");

                    b.HasOne("InitialProject.Model.Tour", "Tour")
                        .WithMany("images")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Accommodation");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("InitialProject.Model.RenovationSuggestion", b =>
                {
                    b.HasOne("InitialProject.Model.AccommodationReservation", "AccommodationReservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccommodationReservation");
                });

            modelBuilder.Entity("InitialProject.Model.ReservationReschedulingRequest", b =>
                {
                    b.HasOne("InitialProject.Model.AccommodationReservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("AccommodationReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("InitialProject.Model.Tour", b =>
                {
                    b.HasOne("InitialProject.Model.User", "Guide")
                        .WithMany()
                        .HasForeignKey("guideID");

                    b.HasOne("InitialProject.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("locationID");

                    b.Navigation("Guide");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("InitialProject.Model.TourKeyPoint", b =>
                {
                    b.HasOne("InitialProject.Model.Tour", "Tour")
                        .WithMany("TourKeyPoints")
                        .HasForeignKey("tourID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("InitialProject.Model.TourRequest", b =>
                {
                    b.HasOne("InitialProject.Model.ComplexTourRequest", "ComplexTourRequest")
                        .WithMany("Requests")
                        .HasForeignKey("ComplexTourRequestId");

                    b.HasOne("InitialProject.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("ComplexTourRequest");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("InitialProject.Model.TourReservation", b =>
                {
                    b.HasOne("InitialProject.Model.User", "BookingGuest")
                        .WithMany()
                        .HasForeignKey("BookingGuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InitialProject.Model.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourId");

                    b.HasOne("InitialProject.Model.TourKeyPoint", "ArrivalPoint")
                        .WithMany()
                        .HasForeignKey("TourKeyPointId");

                    b.HasOne("InitialProject.Model.Voucher", "Voucher")
                        .WithMany()
                        .HasForeignKey("VoucherId");

                    b.Navigation("ArrivalPoint");

                    b.Navigation("BookingGuest");

                    b.Navigation("Tour");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("InitialProject.Model.TourReview", b =>
                {
                    b.HasOne("InitialProject.Model.TourReservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("TourReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("InitialProject.Model.Voucher", b =>
                {
                    b.HasOne("InitialProject.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InitialProject.Model.Accommodation", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("InitialProject.Model.ComplexTourRequest", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("InitialProject.Model.Tour", b =>
                {
                    b.Navigation("TourKeyPoints");

                    b.Navigation("images");
                });
#pragma warning restore 612, 618
        }
    }
}
