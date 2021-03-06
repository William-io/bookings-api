// <auto-generated />
using System;
using Bookings.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookings.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210710230939_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Bookings.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<double>("CurrentSpeed")
                        .HasColumnType("double");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Fuel")
                        .HasColumnType("longtext");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("CarId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Bookings.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bookings.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Gym")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("Pool")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("HotelId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Bookings.Models.Car", b =>
                {
                    b.HasOne("Bookings.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bookings.Models.Hotel", b =>
                {
                    b.HasOne("Bookings.Models.Category", "Category")
                        .WithMany("Hotels")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bookings.Models.Category", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}
