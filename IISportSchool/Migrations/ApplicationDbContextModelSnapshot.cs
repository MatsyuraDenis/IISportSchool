﻿// <auto-generated />
using System;
using IISportSchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IISportSchool.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IISportSchool.Models.Children", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<int?>("GroupId");

                    b.Property<string>("Name");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Childrens");
                });

            modelBuilder.Entity("IISportSchool.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("IISportSchool.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<int>("MaxChildAge");

                    b.Property<int>("MinChildAge");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63);

                    b.Property<int>("PricePerMonth");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("SectionId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("IISportSchool.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("IISportSchool.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId");

                    b.Property<string>("Name");

                    b.Property<int>("Salary");

                    b.Property<string>("SecondName");

                    b.Property<string>("SectionName");

                    b.Property<int>("YearsOfExperience");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .IsUnique()
                        .HasFilter("[GroupId] IS NOT NULL");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("IISportSchool.Models.TeacherProxy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName");

                    b.Property<string>("SectionName");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.ToTable("TeacherProxies");
                });

            modelBuilder.Entity("IISportSchool.Models.Children", b =>
                {
                    b.HasOne("IISportSchool.Models.Group")
                        .WithMany("Childrens")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("IISportSchool.Models.Group", b =>
                {
                    b.HasOne("IISportSchool.Models.Section", "Section")
                        .WithMany("Groups")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IISportSchool.Models.Section", b =>
                {
                    b.HasOne("IISportSchool.Models.Department", "Department")
                        .WithMany("Sections")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IISportSchool.Models.Teacher", b =>
                {
                    b.HasOne("IISportSchool.Models.Group", "Group")
                        .WithOne("Teacher")
                        .HasForeignKey("IISportSchool.Models.Teacher", "GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
