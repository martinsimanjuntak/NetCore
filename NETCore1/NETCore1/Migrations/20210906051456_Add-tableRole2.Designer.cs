﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETCore1.Context;

namespace NETCore1.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210906051456_Add-tableRole2")]
    partial class AddtableRole2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NETCore1.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("NETCore1.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Univesity_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("tb_m_educations");
                });

            modelBuilder.Entity("NETCore1.Models.Person", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_persons");
                });

            modelBuilder.Entity("NETCore1.Models.PersonViewModel", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Education_id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaBelakang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaDepan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TglLahir")
                        .HasColumnType("datetime2");

                    b.Property<string>("Unversity_Id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("PersonViewModels");
                });

            modelBuilder.Entity("NETCore1.Models.Profiling", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EducationId")
                        .HasColumnType("int");

                    b.Property<int>("Education_id")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("EducationId");

                    b.ToTable("tb_m_profilings");
                });

            modelBuilder.Entity("NETCore1.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("NETCore1.Models.RoleAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountNIK");

                    b.HasIndex("RoleId");

                    b.ToTable("tb_m_roleaccounts");
                });

            modelBuilder.Entity("NETCore1.Models.University", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_universities   ");
                });

            modelBuilder.Entity("NETCore1.Models.Account", b =>
                {
                    b.HasOne("NETCore1.Models.Person", "Person")
                        .WithOne("Account")
                        .HasForeignKey("NETCore1.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("NETCore1.Models.Education", b =>
                {
                    b.HasOne("NETCore1.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("University");
                });

            modelBuilder.Entity("NETCore1.Models.Profiling", b =>
                {
                    b.HasOne("NETCore1.Models.Education", "Education")
                        .WithMany("Profilings")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("NETCore1.Models.Account", "Account")
                        .WithOne("Profiling")
                        .HasForeignKey("NETCore1.Models.Profiling", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Education");
                });

            modelBuilder.Entity("NETCore1.Models.RoleAccount", b =>
                {
                    b.HasOne("NETCore1.Models.Account", "Account")
                        .WithMany("RoleAccounts")
                        .HasForeignKey("AccountNIK");

                    b.HasOne("NETCore1.Models.Role", "Role")
                        .WithMany("RoleAccounts")
                        .HasForeignKey("RoleId");

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NETCore1.Models.Account", b =>
                {
                    b.Navigation("Profiling");

                    b.Navigation("RoleAccounts");
                });

            modelBuilder.Entity("NETCore1.Models.Education", b =>
                {
                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("NETCore1.Models.Person", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("NETCore1.Models.Role", b =>
                {
                    b.Navigation("RoleAccounts");
                });

            modelBuilder.Entity("NETCore1.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
