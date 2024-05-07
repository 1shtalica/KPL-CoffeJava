﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hospitalManagenetSystemAPI.Data;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240505151906_update migration 2")]
    partial class updatemigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("hospitalManagementSystemAPI.Models.Gender", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Name");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("AdminId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Appoiment", b =>
                {
                    b.Property<int>("AppoimentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("Sapacity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("TimeEnd")
                        .HasColumnType("time(6)");

                    b.Property<TimeOnly>("TimeStart")
                        .HasColumnType("time(6)");

                    b.HasKey("AppoimentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("RoomId");

                    b.ToTable("Appoiments");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.AppoimentPatient", b =>
                {
                    b.Property<int>("AppoimentId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("AppoimentId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("AppoimentPatients");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.BloodType", b =>
                {
                    b.Property<string>("bloodType")
                        .HasColumnType("varchar(255)");

                    b.HasKey("bloodType");

                    b.ToTable("BloodType");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DoctorId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("SpecializationId");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.MedicalCheckUp", b =>
                {
                    b.Property<int>("MedicalChekUpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("NoteMedicalChekup")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("date")
                        .HasColumnType("date");

                    b.HasKey("MedicalChekUpId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("medicalCheckUps");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("BloodTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("PatientId");

                    b.HasIndex("BloodTypeName");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GenderName");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("patients");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoomFloor")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Specialization", b =>
                {
                    b.Property<int>("SpecializationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SpecializationId");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Appoiment", b =>
                {
                    b.HasOne("hospitalManagenetSystemAPI.Models.Doctor", "Doctor")
                        .WithMany("Appoiments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hospitalManagenetSystemAPI.Models.Room", "Room")
                        .WithMany("Appoiments")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.AppoimentPatient", b =>
                {
                    b.HasOne("hospitalManagenetSystemAPI.Models.Appoiment", "Appoiment")
                        .WithMany()
                        .HasForeignKey("AppoimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hospitalManagenetSystemAPI.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appoiment");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Doctor", b =>
                {
                    b.HasOne("hospitalManagenetSystemAPI.Models.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.MedicalCheckUp", b =>
                {
                    b.HasOne("hospitalManagenetSystemAPI.Models.Doctor", "Doctor")
                        .WithMany("MedicalCheckUps")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hospitalManagenetSystemAPI.Models.Patient", "Patient")
                        .WithMany("medicalCheckUps")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Patient", b =>
                {
                    b.HasOne("hospitalManagenetSystemAPI.Models.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hospitalManagementSystemAPI.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodType");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Doctor", b =>
                {
                    b.Navigation("Appoiments");

                    b.Navigation("MedicalCheckUps");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Patient", b =>
                {
                    b.Navigation("medicalCheckUps");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Room", b =>
                {
                    b.Navigation("Appoiments");
                });

            modelBuilder.Entity("hospitalManagenetSystemAPI.Models.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}