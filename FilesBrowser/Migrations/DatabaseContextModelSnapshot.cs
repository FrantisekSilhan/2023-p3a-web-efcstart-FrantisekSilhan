﻿// <auto-generated />
using System;
using FilesBrowser.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilesBrowser.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("FilesBrowser.Models.Folder", b =>
                {
                    b.Property<Guid>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParentFolderId")
                        .HasColumnType("TEXT");

                    b.HasKey("FolderId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            FolderId = new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb"),
                            Name = "Root",
                            ParentFolderId = new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb")
                        },
                        new
                        {
                            FolderId = new Guid("15c3694b-32e1-478d-96ed-86873a3396f3"),
                            Name = "Music",
                            ParentFolderId = new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb")
                        },
                        new
                        {
                            FolderId = new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d"),
                            Name = "Images",
                            ParentFolderId = new Guid("cf20e53b-de2c-4864-af62-9131fd82e4cb")
                        },
                        new
                        {
                            FolderId = new Guid("d393b30a-7fec-46a6-8318-fb93fb4076a9"),
                            Name = "Orchestral",
                            ParentFolderId = new Guid("15c3694b-32e1-478d-96ed-86873a3396f3")
                        },
                        new
                        {
                            FolderId = new Guid("10e85872-ada5-4d9c-9fae-221117a68f48"),
                            Name = "Pop",
                            ParentFolderId = new Guid("15c3694b-32e1-478d-96ed-86873a3396f3")
                        },
                        new
                        {
                            FolderId = new Guid("4fe5143e-c32d-4c09-b589-e3ef46ddefd4"),
                            Name = "Rock",
                            ParentFolderId = new Guid("15c3694b-32e1-478d-96ed-86873a3396f3")
                        },
                        new
                        {
                            FolderId = new Guid("aa3b5248-f54e-4940-adab-c8e68db50d13"),
                            Name = "Family",
                            ParentFolderId = new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d")
                        },
                        new
                        {
                            FolderId = new Guid("0d84a9eb-e863-46f1-a96f-c98ccbd04c26"),
                            Name = "Wallpapers",
                            ParentFolderId = new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d")
                        },
                        new
                        {
                            FolderId = new Guid("90969de0-de02-4606-85eb-48670193830c"),
                            Name = "Screenshots",
                            ParentFolderId = new Guid("4c87829f-184b-4e8a-b5ad-d79b276f699d")
                        });
                });

            modelBuilder.Entity("FilesBrowser.Models.Folder", b =>
                {
                    b.HasOne("FilesBrowser.Models.Folder", "ParentFolder")
                        .WithMany("Folders")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("FilesBrowser.Models.Folder", b =>
                {
                    b.Navigation("Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
