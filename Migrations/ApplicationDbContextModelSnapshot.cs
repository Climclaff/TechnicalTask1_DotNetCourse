﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalTask1_DotNetCourse.Data;

#nullable disable

namespace TechnicalTask1_DotNetCourse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechnicalTask1_DotNetCourse.Models.Catalog", b =>
                {
                    b.Property<int>("CatalogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatalogId"));

                    b.Property<string>("CatalogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCatalogId")
                        .HasColumnType("int");

                    b.HasKey("CatalogId");

                    b.HasIndex("ParentCatalogId");

                    b.ToTable("Catalogs", (string)null);
                });

            modelBuilder.Entity("TechnicalTask1_DotNetCourse.Models.Catalog", b =>
                {
                    b.HasOne("TechnicalTask1_DotNetCourse.Models.Catalog", "ParentCatalog")
                        .WithMany("ChildCatalogs")
                        .HasForeignKey("ParentCatalogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentCatalog");
                });

            modelBuilder.Entity("TechnicalTask1_DotNetCourse.Models.Catalog", b =>
                {
                    b.Navigation("ChildCatalogs");
                });
#pragma warning restore 612, 618
        }
    }
}
