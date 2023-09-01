﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScreenSound.Data;

#nullable disable

namespace ScreenSound.Migrations
{
    [DbContext(typeof(ScreenSoundContext))]
    [Migration("20230829192244_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScreenSound.Models.Banda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nome_artista");

                    b.HasKey("Id");

                    b.ToTable("artista", (string)null);
                });

            modelBuilder.Entity("ScreenSound.Models.Musica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<byte>("Duracao")
                        .HasColumnType("tinyint")
                        .HasColumnName("duracao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nome_musica");

                    b.Property<int>("artista_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("artista_id");

                    b.ToTable("musica", (string)null);
                });

            modelBuilder.Entity("ScreenSound.Models.Musica", b =>
                {
                    b.HasOne("ScreenSound.Models.Banda", "Artista")
                        .WithMany("Musicas")
                        .HasForeignKey("artista_id")
                        .IsRequired();

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("ScreenSound.Models.Banda", b =>
                {
                    b.Navigation("Musicas");
                });
#pragma warning restore 612, 618
        }
    }
}
