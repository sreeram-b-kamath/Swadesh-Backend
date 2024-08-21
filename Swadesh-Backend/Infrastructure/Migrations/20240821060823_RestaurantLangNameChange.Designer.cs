﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shared.Data;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240821060823_RestaurantLangNameChange")]
    partial class RestaurantLangNameChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.MasterCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DefaultOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("masterCategories");
                });

            modelBuilder.Entity("Models.MasterCategoryLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MasterCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MasterCategoryId", "Code")
                        .IsUnique();

                    b.ToTable("masterCategoryLangs");
                });

            modelBuilder.Entity("Models.MasterFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DefaultOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Icons")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("masterFilters");
                });

            modelBuilder.Entity("Models.MasterFilterLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MasterFilterId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MasterFilterId", "Code")
                        .IsUnique();

                    b.ToTable("masterFilterLangs");
                });

            modelBuilder.Entity("Models.MenuCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.HasIndex("Name", "RestaurantId")
                        .IsUnique();

                    b.ToTable("menuCategories");
                });

            modelBuilder.Entity("Models.MenuCategoryLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MenuCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("MenuCategoryId", "RestaurantId", "Code")
                        .IsUnique();

                    b.ToTable("menuCategoryLangs");
                });

            modelBuilder.Entity("Models.MenuFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("Name", "RestaurantId")
                        .IsUnique();

                    b.ToTable("menuFilters");
                });

            modelBuilder.Entity("Models.MenuFilterLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MenuFiltersId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("MenuFiltersId", "RestaurantId", "Code")
                        .IsUnique();

                    b.ToTable("menuFilterLangs");
                });

            modelBuilder.Entity("Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("InStock")
                        .HasColumnType("boolean");

                    b.Property<int>("MenuCategoryId")
                        .HasColumnType("integer");

                    b.Property<int[]>("MenuFilterIds")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<decimal>("Money")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("PrimaryImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.Property<Guid>("uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MenuCategoryId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("menuItems");
                });

            modelBuilder.Entity("Models.MenuItemLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MenuItemsId")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("MenuItemsId", "RestaurantId", "Code")
                        .IsUnique();

                    b.ToTable("menuItemLangs");
                });

            modelBuilder.Entity("Models.MenuItemRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("RestaurantId", "SessionId", "MenuItemId")
                        .IsUnique();

                    b.ToTable("menuItemRatings");
                });

            modelBuilder.Entity("Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cuisine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("InitialLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OTP")
                        .HasColumnType("integer");

                    b.Property<bool>("OTPUsed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("OtpExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Roles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdateEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isEmailVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("restaurants");
                });

            modelBuilder.Entity("Models.RestaurantLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId", "Code")
                        .IsUnique();

                    b.ToTable("restaurantLangs");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsEmailVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("OTP")
                        .HasColumnType("integer");

                    b.Property<bool>("OTPUsed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("OtpExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Shared.ErrorMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("errorMessages");
                });

            modelBuilder.Entity("Models.MasterCategoryLang", b =>
                {
                    b.HasOne("Models.MasterCategory", "MasterCategory")
                        .WithMany("MasterCategoryLanguage")
                        .HasForeignKey("MasterCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterCategory");
                });

            modelBuilder.Entity("Models.MasterFilterLang", b =>
                {
                    b.HasOne("Models.MasterFilter", "MasterFilter")
                        .WithMany("MasterFilterLanguage")
                        .HasForeignKey("MasterFilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterFilter");
                });

            modelBuilder.Entity("Models.MenuCategory", b =>
                {
                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("MenuCategories")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MenuCategoryLang", b =>
                {
                    b.HasOne("Models.MenuCategory", "MenuCategory")
                        .WithMany("MenuCategoryLanguage")
                        .HasForeignKey("MenuCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("MenuCategoryLangs")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuCategory");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MenuFilter", b =>
                {
                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("MenuFilters")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MenuFilterLang", b =>
                {
                    b.HasOne("Models.MenuFilter", "MenuFilters")
                        .WithMany("MenuFilterlang")
                        .HasForeignKey("MenuFiltersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("MenuFiltersLangs")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuFilters");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MenuItem", b =>
                {
                    b.HasOne("Models.MenuCategory", "MenuCategory")
                        .WithMany()
                        .HasForeignKey("MenuCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuCategory");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MenuItemLang", b =>
                {
                    b.HasOne("Models.MenuItem", "MenuItems")
                        .WithMany("MenuItemslang")
                        .HasForeignKey("MenuItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("MenuItemsLangs")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItems");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MenuItemRating", b =>
                {
                    b.HasOne("Models.MenuItem", "MenuItem")
                        .WithMany("MenuItemRatings")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("MenuItemRatings")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.RestaurantLang", b =>
                {
                    b.HasOne("Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantLang")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MasterCategory", b =>
                {
                    b.Navigation("MasterCategoryLanguage");
                });

            modelBuilder.Entity("Models.MasterFilter", b =>
                {
                    b.Navigation("MasterFilterLanguage");
                });

            modelBuilder.Entity("Models.MenuCategory", b =>
                {
                    b.Navigation("MenuCategoryLanguage");
                });

            modelBuilder.Entity("Models.MenuFilter", b =>
                {
                    b.Navigation("MenuFilterlang");
                });

            modelBuilder.Entity("Models.MenuItem", b =>
                {
                    b.Navigation("MenuItemRatings");

                    b.Navigation("MenuItemslang");
                });

            modelBuilder.Entity("Models.Restaurant", b =>
                {
                    b.Navigation("MenuCategories");

                    b.Navigation("MenuCategoryLangs");

                    b.Navigation("MenuFilters");

                    b.Navigation("MenuFiltersLangs");

                    b.Navigation("MenuItemRatings");

                    b.Navigation("MenuItems");

                    b.Navigation("MenuItemsLangs");

                    b.Navigation("RestaurantLang");
                });
#pragma warning restore 612, 618
        }
    }
}
