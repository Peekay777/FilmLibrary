using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FilmLibrary.Data;

namespace FilmLibrary.Migrations
{
    [DbContext(typeof(FilmLibraryContext))]
    partial class FilmLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
