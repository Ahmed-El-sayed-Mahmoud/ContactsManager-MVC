﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240404151540_8th")]
    partial class _8th
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Country", b =>
                {
                    b.Property<Guid?>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries", (string)null);

                    b.HasData(
                        new
                        {
                            CountryID = new Guid("14629847-905a-4a0e-9abe-80b61655c5cb"),
                            CountryName = "Philippines"
                        },
                        new
                        {
                            CountryID = new Guid("56bf46a4-02b8-4693-a0f5-0a95e2218bdc"),
                            CountryName = "Thailand"
                        },
                        new
                        {
                            CountryID = new Guid("12e15727-d369-49a9-8b13-bc22e9362179"),
                            CountryName = "China"
                        },
                        new
                        {
                            CountryID = new Guid("8f30bedc-47dd-4286-8950-73d8a68e5d41"),
                            CountryName = "Palestinian Territory"
                        },
                        new
                        {
                            CountryID = new Guid("501c6d33-1bbe-45f1-8fbd-2275913c6218"),
                            CountryName = "China"
                        });
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.Property<Guid>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<Guid?>("CountryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("ReceiveNewsLetters")
                        .HasColumnType("bit");

                    b.HasKey("PersonID");

                    b.ToTable("Persons", (string)null);

                    b.HasData(
                        new
                        {
                            PersonID = new Guid("c03bbe45-9aeb-4d24-99e0-4743016ffce9"),
                            Address = "4 Parkside Point",
                            CountryID = new Guid("56bf46a4-02b8-4693-a0f5-0a95e2218bdc"),
                            DateOfBirth = new DateTime(1989, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mwebsdale0@people.com.cn",
                            Gender = "Female",
                            PersonName = "Marguerite",
                            ReceiveNewsLetters = false
                        },
                        new
                        {
                            PersonID = new Guid("c3abddbd-cf50-41d2-b6c4-cc7d5a750928"),
                            Address = "6 Morningstar Circle",
                            CountryID = new Guid("14629847-905a-4a0e-9abe-80b61655c5cb"),
                            DateOfBirth = new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ushears1@globo.com",
                            Gender = "Female",
                            PersonName = "Ursa",
                            ReceiveNewsLetters = false
                        },
                        new
                        {
                            PersonID = new Guid("c6d50a47-f7e6-4482-8be0-4ddfc057fa6e"),
                            Address = "73 Heath Avenue",
                            CountryID = new Guid("14629847-905a-4a0e-9abe-80b61655c5cb"),
                            DateOfBirth = new DateTime(1995, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fbowsher2@howstuffworks.com",
                            Gender = "Male",
                            PersonName = "Franchot",
                            ReceiveNewsLetters = true
                        },
                        new
                        {
                            PersonID = new Guid("d15c6d9f-70b4-48c5-afd3-e71261f1a9be"),
                            Address = "83187 Merry Drive",
                            CountryID = new Guid("12e15727-d369-49a9-8b13-bc22e9362179"),
                            DateOfBirth = new DateTime(1987, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "asarvar3@dropbox.com",
                            Gender = "Male",
                            PersonName = "Angie",
                            ReceiveNewsLetters = true
                        },
                        new
                        {
                            PersonID = new Guid("89e5f445-d89f-4e12-94e0-5ad5b235d704"),
                            Address = "50467 Holy Cross Crossing",
                            CountryID = new Guid("56bf46a4-02b8-4693-a0f5-0a95e2218bdc"),
                            DateOfBirth = new DateTime(1995, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ttregona4@stumbleupon.com",
                            Gender = "Female",
                            PersonName = "Tani",
                            ReceiveNewsLetters = false
                        },
                        new
                        {
                            PersonID = new Guid("2a6d3738-9def-43ac-9279-0310edc7ceca"),
                            Address = "97570 Raven Circle",
                            CountryID = new Guid("8f30bedc-47dd-4286-8950-73d8a68e5d41"),
                            DateOfBirth = new DateTime(1988, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mlingfoot5@netvibes.com",
                            Gender = "Male",
                            PersonName = "Mitchael",
                            ReceiveNewsLetters = false
                        },
                        new
                        {
                            PersonID = new Guid("29339209-63f5-492f-8459-754943c74abf"),
                            Address = "57449 Brown Way",
                            CountryID = new Guid("12e15727-d369-49a9-8b13-bc22e9362179"),
                            DateOfBirth = new DateTime(1983, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mjarrell6@wisc.edu",
                            Gender = "Male",
                            PersonName = "Maddy",
                            ReceiveNewsLetters = true
                        },
                        new
                        {
                            PersonID = new Guid("ac660a73-b0b7-4340-abc1-a914257a6189"),
                            Address = "4 Stuart Drive",
                            CountryID = new Guid("12e15727-d369-49a9-8b13-bc22e9362179"),
                            DateOfBirth = new DateTime(1998, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pretchford7@virginia.edu",
                            Gender = "Female",
                            PersonName = "Pegeen",
                            ReceiveNewsLetters = true
                        },
                        new
                        {
                            PersonID = new Guid("012107df-862f-4f16-ba94-e5c16886f005"),
                            Address = "413 Sachtjen Way",
                            CountryID = new Guid("12e15727-d369-49a9-8b13-bc22e9362179"),
                            DateOfBirth = new DateTime(1990, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hmosco8@tripod.com",
                            Gender = "Male",
                            PersonName = "Hansiain",
                            ReceiveNewsLetters = true
                        },
                        new
                        {
                            PersonID = new Guid("cb035f22-e7cf-4907-bd07-91cfee5240f3"),
                            Address = "484 Clarendon Court",
                            CountryID = new Guid("8f30bedc-47dd-4286-8950-73d8a68e5d41"),
                            DateOfBirth = new DateTime(1997, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lwoodwing9@wix.com",
                            Gender = "Male",
                            PersonName = "Lombard",
                            ReceiveNewsLetters = false
                        },
                        new
                        {
                            PersonID = new Guid("28d11936-9466-4a4b-b9c5-2f0a8e0cbde9"),
                            Address = "2 Warrior Avenue",
                            CountryID = new Guid("501c6d33-1bbe-45f1-8fbd-2275913c6218"),
                            DateOfBirth = new DateTime(1990, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mconachya@va.gov",
                            Gender = "Female",
                            PersonName = "Minta",
                            ReceiveNewsLetters = true
                        },
                        new
                        {
                            PersonID = new Guid("a3b9833b-8a4d-43e9-8690-61e08df81a9a"),
                            Address = "9334 Fremont Street",
                            CountryID = new Guid("501c6d33-1bbe-45f1-8fbd-2275913c6218"),
                            DateOfBirth = new DateTime(1987, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "vklussb@nationalgeographic.com",
                            Gender = "Female",
                            PersonName = "Verene",
                            ReceiveNewsLetters = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
