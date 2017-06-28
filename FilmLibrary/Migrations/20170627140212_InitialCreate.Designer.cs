using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FilmLibrary.Data.Sql;
using FilmLibrary.Data;

namespace FilmLibrary.Migrations
{
    [DbContext(typeof(FilmLibraryContext))]
    [Migration("20170627140212_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("FilmLibrary.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ReleaseDate");

                    b.Property<ushort>("Runtime");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });
        }
    }
}
