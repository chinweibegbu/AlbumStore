﻿// <auto-generated />
using System;
using AlbumStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlbumStore.Migrations
{
    [DbContext(typeof(AlbumStoreContext))]
    [Migration("20211104074414_GenreListToArray")]
    partial class GenreListToArray
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlbumStore.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("AlbumStore.Models.AlbumGenre", b =>
                {
                    b.Property<int>("AlbumGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int?>("MusicGenreGenreId")
                        .HasColumnType("int");

                    b.HasKey("AlbumGenreId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("MusicGenreGenreId");

                    b.ToTable("AlbumGenres");
                });

            modelBuilder.Entity("AlbumStore.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Artist");
                });

            modelBuilder.Entity("AlbumStore.Models.ArtistDescription", b =>
                {
                    b.Property<int>("ArtistDescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistDescriptionId");

                    b.HasIndex("ArtistID")
                        .IsUnique();

                    b.ToTable("ArtistDescriptions");
                });

            modelBuilder.Entity("AlbumStore.Models.MusicGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("MusicGenres");
                });

            modelBuilder.Entity("AlbumStore.Models.SoloArtist", b =>
                {
                    b.HasBaseType("AlbumStore.Models.Artist");

                    b.Property<string>("Instrument")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("SoloArtist");
                });

            modelBuilder.Entity("AlbumStore.Models.Album", b =>
                {
                    b.HasOne("AlbumStore.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("AlbumStore.Models.AlbumGenre", b =>
                {
                    b.HasOne("AlbumStore.Models.Album", "Album")
                        .WithMany("AlbumGenres")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlbumStore.Models.MusicGenre", "MusicGenre")
                        .WithMany("AlbumGenres")
                        .HasForeignKey("MusicGenreGenreId");

                    b.Navigation("Album");

                    b.Navigation("MusicGenre");
                });

            modelBuilder.Entity("AlbumStore.Models.ArtistDescription", b =>
                {
                    b.HasOne("AlbumStore.Models.Artist", "Artist")
                        .WithOne("ArtistDescription")
                        .HasForeignKey("AlbumStore.Models.ArtistDescription", "ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("AlbumStore.Models.Album", b =>
                {
                    b.Navigation("AlbumGenres");
                });

            modelBuilder.Entity("AlbumStore.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("ArtistDescription");
                });

            modelBuilder.Entity("AlbumStore.Models.MusicGenre", b =>
                {
                    b.Navigation("AlbumGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
