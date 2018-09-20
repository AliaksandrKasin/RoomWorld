﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Models;

namespace Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entity.Amenties", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("FlatId");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FlatId");

                    b.ToTable("Amentiese");
                });

            modelBuilder.Entity("Data.Entity.Extras", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cost")
                        .IsRequired();

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("FlatId");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FlatId");

                    b.ToTable("Extrase");
                });

            modelBuilder.Entity("Data.Entity.Flat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Accommodates");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<double>("Cost");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<long?>("LocationId");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<double>("Size");

                    b.Property<string>("SpaceOffered");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Flat");
                });

            modelBuilder.Entity("Data.Entity.HouseRules", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("FlatId");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<bool>("State");

                    b.HasKey("Id");

                    b.HasIndex("FlatId");

                    b.ToTable("HouseRulese");
                });

            modelBuilder.Entity("Data.Entity.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("GpsPoint");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("NumberFlat");

                    b.Property<int>("NumberHouse");

                    b.Property<int>("NumberHouseBlock");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Data.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Role");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data.Entity.Amenties", b =>
                {
                    b.HasOne("Data.Entity.Flat", "Flat")
                        .WithMany("Amentieses")
                        .HasForeignKey("FlatId");
                });

            modelBuilder.Entity("Data.Entity.Extras", b =>
                {
                    b.HasOne("Data.Entity.Flat", "Flat")
                        .WithMany("Extrases")
                        .HasForeignKey("FlatId");
                });

            modelBuilder.Entity("Data.Entity.Flat", b =>
                {
                    b.HasOne("Data.Entity.Location", "Location")
                        .WithMany("Flat")
                        .HasForeignKey("LocationId");

                    b.HasOne("Data.Entity.User", "User")
                        .WithMany("Flats")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Data.Entity.HouseRules", b =>
                {
                    b.HasOne("Data.Entity.Flat", "Flat")
                        .WithMany("HouseRuleses")
                        .HasForeignKey("FlatId");
                });
#pragma warning restore 612, 618
        }
    }
}
