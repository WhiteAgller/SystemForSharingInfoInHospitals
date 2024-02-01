﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientManagement.Infrastructure.Data;

#nullable disable

namespace PatientManagement.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PatientDbContext))]
    [Migration("20240201234925_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientManagement.Domain.Entities.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalRecord");
                });

            modelBuilder.Entity("PatientManagement.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PatientManagement.Domain.Entities.MedicalRecord", b =>
                {
                    b.HasOne("PatientManagement.Domain.Entities.Patient", null)
                        .WithOne("MedicalRecord")
                        .HasForeignKey("PatientManagement.Domain.Entities.MedicalRecord", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("PatientManagement.Domain.Entities.Difficulty", "Difficulties", b1 =>
                        {
                            b1.Property<int>("MedicalRecordId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Diagnosis")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("DoctorId")
                                .HasColumnType("int");

                            b1.Property<string>("TreatmentPlan")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("MedicalRecordId", "Id");

                            b1.ToTable("Difficulty");

                            b1.WithOwner()
                                .HasForeignKey("MedicalRecordId");
                        });

                    b.Navigation("Difficulties");
                });

            modelBuilder.Entity("PatientManagement.Domain.Entities.Patient", b =>
                {
                    b.OwnsMany("PatientManagement.Domain.ValueObjects.Alergy", "Alergies", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientId", "Id");

                            b1.ToTable("Alergy");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Alergies");
                });

            modelBuilder.Entity("PatientManagement.Domain.Entities.Patient", b =>
                {
                    b.Navigation("MedicalRecord")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
