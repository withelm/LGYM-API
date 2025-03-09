﻿// <auto-generated />
using System;
using Lgym.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lgym.Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lgym.Services.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyPart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OwnerId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Lgym.Services.Models.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OwnerId");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("Lgym.Services.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lgym.Services.Models.Exercise", b =>
                {
                    b.HasOne("Lgym.Services.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Lgym.Services.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("Lgym.Services.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Lgym.Services.Models.Gym", b =>
                {
                    b.HasOne("Lgym.Services.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Lgym.Services.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("Lgym.Services.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Lgym.Services.Models.User", b =>
                {
                    b.HasOne("Lgym.Services.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Lgym.Services.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
