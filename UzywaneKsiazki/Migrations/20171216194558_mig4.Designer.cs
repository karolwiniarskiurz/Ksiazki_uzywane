﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using UzywaneKsiazki.Models.Repository;

namespace UzywaneKsiazki.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171216194558_mig4")]
    partial class mig4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UzywaneKsiazki.Models.DomainModels.PostModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<string>("AuthorName");

                    b.Property<string>("BookAuthor");

                    b.Property<DateTime>("DateOfPosting");

                    b.Property<string>("Description");

                    b.Property<string>("PhotosDb");

                    b.Property<decimal?>("Price");

                    b.Property<string>("PublishDate");

                    b.Property<string>("StateOfBook");

                    b.Property<string>("Telephone");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
