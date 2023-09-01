﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScreenSound.Data;

#nullable disable

namespace ScreenSound.Migrations
{
    [DbContext(typeof(ScreenSoundContext))]
    partial class ScreenSoundContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScreenSound.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome_album");

                    b.Property<int>("artista_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasAlternateKey("Nome");

                    b.HasIndex("artista_id");

                    b.ToTable("album", (string)null);
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Nota")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int>("album_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("rated_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("album_id");

                    b.ToTable("avalicao_album", (string)null);
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoBanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Nota")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int>("banda_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("rated_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("banda_id");

                    b.ToTable("avaliacao_banda", (string)null);
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoMusica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Nota")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int>("musica_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("rated_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("musica_id");

                    b.ToTable("avaliacao_musica", (string)null);
                });

            modelBuilder.Entity("ScreenSound.Models.Banda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)")
                        .HasColumnName("detalhes");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nome_artista");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasAlternateKey("Nome");

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
                        .HasColumnType("bit")
                        .HasColumnName("disponivel");

                    b.Property<short>("Duracao")
                        .HasColumnType("smallint")
                        .HasColumnName("duracao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nome_musica");

                    b.Property<int>("album_id")
                        .HasColumnType("int");

                    b.Property<int>("artista_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasAlternateKey("Nome");

                    b.HasIndex("album_id");

                    b.HasIndex("artista_id");

                    b.ToTable("musica", (string)null);
                });

            modelBuilder.Entity("ScreenSound.Models.Album", b =>
                {
                    b.HasOne("ScreenSound.Models.Banda", "ArtistaBanda")
                        .WithMany("AlbumsDaBanda")
                        .HasForeignKey("artista_id")
                        .IsRequired();

                    b.Navigation("ArtistaBanda");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoAlbum", b =>
                {
                    b.HasOne("ScreenSound.Models.Album", "Album")
                        .WithMany("NotasAlbum")
                        .HasForeignKey("album_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoBanda", b =>
                {
                    b.HasOne("ScreenSound.Models.Banda", "Banda")
                        .WithMany("NotasBanda")
                        .HasForeignKey("banda_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banda");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoMusica", b =>
                {
                    b.HasOne("ScreenSound.Models.Musica", "Musica")
                        .WithMany("AvaliacaoMusicas")
                        .HasForeignKey("musica_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musica");
                });

            modelBuilder.Entity("ScreenSound.Models.Musica", b =>
                {
                    b.HasOne("ScreenSound.Models.Album", "Album")
                        .WithMany("Musicas")
                        .HasForeignKey("album_id")
                        .IsRequired();

                    b.HasOne("ScreenSound.Models.Banda", "Artista")
                        .WithMany("Musicas")
                        .HasForeignKey("artista_id")
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("ScreenSound.Models.Album", b =>
                {
                    b.Navigation("Musicas");

                    b.Navigation("NotasAlbum");
                });

            modelBuilder.Entity("ScreenSound.Models.Banda", b =>
                {
                    b.Navigation("AlbumsDaBanda");

                    b.Navigation("Musicas");

                    b.Navigation("NotasBanda");
                });

            modelBuilder.Entity("ScreenSound.Models.Musica", b =>
                {
                    b.Navigation("AvaliacaoMusicas");
                });
#pragma warning restore 612, 618
        }
    }
}
