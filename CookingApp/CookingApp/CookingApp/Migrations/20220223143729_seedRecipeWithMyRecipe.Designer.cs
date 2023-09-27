﻿// <auto-generated />
using System;
using CookingApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CookingApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220223143729_seedRecipeWithMyRecipe")]
    partial class seedRecipeWithMyRecipe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CookingApp.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Email = "octa.prescura@gmail.com",
                            FirstName = "Octa",
                            LastName = "Prescura"
                        },
                        new
                        {
                            AuthorId = 2,
                            Email = "robert.prescura@gmail.com",
                            FirstName = "Robert",
                            LastName = "Prescura"
                        });
                });

            modelBuilder.Entity("CookingApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Prajituri"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Bauturi"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Preparate din peste"
                        });
                });

            modelBuilder.Entity("CookingApp.Models.Ingredients", b =>
                {
                    b.Property<int>("IngredientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientsId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientsId = 1,
                            Amount = "3",
                            Name = "mar",
                            Unit = "buc"
                        },
                        new
                        {
                            IngredientsId = 2,
                            Amount = "200",
                            Name = "ciocolata",
                            Unit = "g"
                        },
                        new
                        {
                            IngredientsId = 3,
                            Amount = "500",
                            Name = "lapte",
                            Unit = "ml"
                        },
                        new
                        {
                            IngredientsId = 4,
                            Amount = "200",
                            Name = "smantana lichida",
                            Unit = "ml"
                        },
                        new
                        {
                            IngredientsId = 5,
                            Amount = "3",
                            Name = "zahar",
                            Unit = "linguri"
                        },
                        new
                        {
                            IngredientsId = 6,
                            Amount = "150",
                            Name = "faina",
                            Unit = "g"
                        },
                        new
                        {
                            IngredientsId = 7,
                            Amount = "2",
                            Name = "oua",
                            Unit = "buc"
                        },
                        new
                        {
                            IngredientsId = 8,
                            Amount = "75",
                            Name = "ulei",
                            Unit = "ml"
                        },
                        new
                        {
                            IngredientsId = 9,
                            Amount = "50",
                            Name = "unt",
                            Unit = "g"
                        },
                        new
                        {
                            IngredientsId = 10,
                            Amount = "150",
                            Name = "unt de arahide",
                            Unit = "g"
                        },
                        new
                        {
                            IngredientsId = 11,
                            Amount = "4",
                            Name = "lamaie",
                            Unit = "buc"
                        },
                        new
                        {
                            IngredientsId = 12,
                            Amount = "150",
                            Name = "miere",
                            Unit = "g"
                        },
                        new
                        {
                            IngredientsId = 13,
                            Amount = "1",
                            Name = "apa plata",
                            Unit = "l"
                        },
                        new
                        {
                            IngredientsId = 14,
                            Amount = "1-2",
                            Name = "portocala",
                            Unit = "buc"
                        },
                        new
                        {
                            IngredientsId = 15,
                            Amount = "1",
                            Name = "praf de copt",
                            Unit = "plic"
                        },
                        new
                        {
                            IngredientsId = 16,
                            Amount = "2",
                            Name = "esenta de vanilie",
                            Unit = "lingurite"
                        },
                        new
                        {
                            IngredientsId = 17,
                            Amount = "650",
                            Name = "file de somon",
                            Unit = "g"
                        },
                        new
                        {
                            IngredientsId = 18,
                            Amount = "5",
                            Name = "sare",
                            Unit = "g"
                        });
                });

            modelBuilder.Entity("CookingApp.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("CookingTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Kcal")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreparationTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Recipe");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            AuthorId = 1,
                            Description = "Cu mere",
                            Image = "C:/Users/presc/OneDrive/Desktop/placinta-cu-mere.jpg",
                            Kcal = 0.0,
                            Name = "Tort de mere"
                        },
                        new
                        {
                            RecipeId = 2,
                            AuthorId = 2,
                            Description = "Cu mere",
                            Image = "C:/Users/presc/OneDrive/Desktop/placinta-cu-mere.jpg",
                            Kcal = 0.0,
                            Name = "Prajitura cu mere"
                        },
                        new
                        {
                            RecipeId = 3,
                            AuthorId = 2,
                            CookingTime = "200 min",
                            Description = "cu ce vreau eu",
                            Image = "C:/Users/presc/OneDrive/Desktop/placinta-cu-mere.jpg",
                            Kcal = 100.0,
                            Name = "Prajitura casei",
                            PreparationTime = "200 h"
                        });
                });

            modelBuilder.Entity("CookingApp.Models.RecipeCategory", b =>
                {
                    b.Property<int>("RecipeCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("RecipeCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeCategory");

                    b.HasData(
                        new
                        {
                            RecipeCategoryId = 1,
                            CategoryId = 1,
                            RecipeId = 1006
                        },
                        new
                        {
                            RecipeCategoryId = 2,
                            CategoryId = 2,
                            RecipeId = 1006
                        },
                        new
                        {
                            RecipeCategoryId = 3,
                            CategoryId = 2,
                            RecipeId = 1007
                        },
                        new
                        {
                            RecipeCategoryId = 4,
                            CategoryId = 1,
                            RecipeId = 1008
                        },
                        new
                        {
                            RecipeCategoryId = 5,
                            CategoryId = 2,
                            RecipeId = 1009
                        },
                        new
                        {
                            RecipeCategoryId = 6,
                            CategoryId = 1,
                            RecipeId = 1010
                        },
                        new
                        {
                            RecipeCategoryId = 7,
                            CategoryId = 3,
                            RecipeId = 1011
                        });
                });

            modelBuilder.Entity("CookingApp.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("RecipeIngredientId");

                    b.HasIndex("IngredientsId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("CookingApp.Models.Recipe", b =>
                {
                    b.HasOne("CookingApp.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("CookingApp.Models.RecipeCategory", b =>
                {
                    b.HasOne("CookingApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookingApp.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CookingApp.Models.RecipeIngredient", b =>
                {
                    b.HasOne("CookingApp.Models.Ingredients", "Ingredients")
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookingApp.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredients");

                    b.Navigation("Recipe");
                });
#pragma warning restore 612, 618
        }
    }
}
