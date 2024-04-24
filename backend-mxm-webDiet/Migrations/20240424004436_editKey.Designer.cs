﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mxm_webDiet.Domains.dbContext;

#nullable disable

namespace backend_mxm_webDiet.Migrations
{
    [DbContext(typeof(DietDbContext))]
    [Migration("20240424004436_editKey")]
    partial class editKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("mxm_webDiet.Domains.Dto.ChoiceDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChoiceDTO");
                });

            modelBuilder.Entity("mxm_webDiet.Domains.Dto.ResponseApiDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChoiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceId");

                    b.ToTable("ResponseApiDTO");
                });

            modelBuilder.Entity("mxm_webDiet.Domains.Models.Dietas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserCpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("responseApiDTOId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("responseApiDTOId");

                    b.ToTable("Dietas");
                });

            modelBuilder.Entity("mxm_webDiet.Domains.Dto.ResponseApiDTO", b =>
                {
                    b.HasOne("mxm_webDiet.Domains.Dto.ChoiceDTO", "Choice")
                        .WithMany()
                        .HasForeignKey("ChoiceId");

                    b.Navigation("Choice");
                });

            modelBuilder.Entity("mxm_webDiet.Domains.Models.Dietas", b =>
                {
                    b.HasOne("mxm_webDiet.Domains.Dto.ResponseApiDTO", "responseApiDTO")
                        .WithMany()
                        .HasForeignKey("responseApiDTOId");

                    b.Navigation("responseApiDTO");
                });
#pragma warning restore 612, 618
        }
    }
}
