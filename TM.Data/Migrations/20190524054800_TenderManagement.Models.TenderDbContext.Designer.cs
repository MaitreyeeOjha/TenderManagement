﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TM.Data;

namespace TM.Data.Migrations
{
    [DbContext(typeof(TenderDbContext))]
    [Migration("20190524054800_TenderManagement.Models.TenderDbContext")]
    partial class TenderManagementModelsTenderDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TM.Data.Tender", b =>
                {
                    b.Property<int>("TenderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ClosingDate");

                    b.Property<int?>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("TenderId");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Tender");
                });

            modelBuilder.Entity("TM.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastLoginDate");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TM.Data.Tender", b =>
                {
                    b.HasOne("TM.Data.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
