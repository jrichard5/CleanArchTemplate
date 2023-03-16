﻿// <auto-generated />
using InfrrastructureLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfrrastructureLayer.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20230314152143_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationLayer.Entities.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatId"));

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CatOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatId");

                    b.ToTable("Cats");
                });
#pragma warning restore 612, 618
        }
    }
}
