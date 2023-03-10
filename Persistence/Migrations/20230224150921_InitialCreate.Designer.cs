// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230224150921_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Domain.Models.QuoteSubmissionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CompanyFound")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanySupplier")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAndTimeOfOrder")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MostCompetitiveRate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ParcelHeight")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ParcelLength")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ParcelWeight")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ParcelWidth")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("QuoteRequestData");
                });
#pragma warning restore 612, 618
        }
    }
}
