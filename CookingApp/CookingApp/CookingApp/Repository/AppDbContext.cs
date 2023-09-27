using CookingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CookingApp.Repository
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategory { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRecipe> UserRecipe { get; set; }
        public DbSet<RecipeByUser> RecipeByUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Author Table
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, FirstName = "Octa", LastName = "Prescura", Email = "octa.prescura@gmail.com" });
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 2, FirstName = "Robert", LastName = "Prescura", Email = "robert.prescura@gmail.com" });

            //Seed Recipe Table
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { RecipeId = 1, Name = "Tort de mere", Description = "Cu mere", Image = "C:/Users/presc/OneDrive/Desktop/placinta-cu-mere.jpg", AuthorId = 1 });
            modelBuilder.Entity<Recipe>().HasData(
               new Recipe { RecipeId = 2, Name = "Prajitura cu mere", Description = "Cu mere", Image = "C:/Users/presc/OneDrive/Desktop/placinta-cu-mere.jpg", AuthorId = 2 });
            modelBuilder.Entity<Recipe>().HasData(
               new Recipe { RecipeId = 3, Name = "Prajitura casei", Description = "cu ce vreau eu", Image = "C:/Users/presc/OneDrive/Desktop/placinta-cu-mere.jpg", Kcal = 100, CookingTime = "200 min", PreparationTime = "200 h", AuthorId = 2 });

            //Seed Category Table
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Prajituri" });
            modelBuilder.Entity<Category>().HasData(
               new Category { CategoryId = 2, Name = "Bauturi" });
            modelBuilder.Entity<Category>().HasData(
               new Category { CategoryId = 3, Name = "Preparate din peste" });

            //Seed RecipeCategory Table
            modelBuilder.Entity<RecipeCategory>().HasData(
                new RecipeCategory { RecipeCategoryId = 1, RecipeId = 1006, CategoryId = 1 });
            modelBuilder.Entity<RecipeCategory>().HasData(
                new RecipeCategory { RecipeCategoryId = 2, RecipeId = 1006, CategoryId = 2 });
            modelBuilder.Entity<RecipeCategory>().HasData(
                new RecipeCategory { RecipeCategoryId = 3, RecipeId = 1007, CategoryId = 2 });
            modelBuilder.Entity<RecipeCategory>().HasData(
                new RecipeCategory { RecipeCategoryId = 4, RecipeId = 1008, CategoryId = 1 });
            modelBuilder.Entity<RecipeCategory>().HasData(
               new RecipeCategory { RecipeCategoryId = 5, RecipeId = 1009, CategoryId = 2 });
            modelBuilder.Entity<RecipeCategory>().HasData(
               new RecipeCategory { RecipeCategoryId = 6, RecipeId = 1010, CategoryId = 1 });
            modelBuilder.Entity<RecipeCategory>().HasData(
               new RecipeCategory { RecipeCategoryId = 7, RecipeId = 1011, CategoryId = 3 });

            //Seed Ingredients Table
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { IngredientsId = 1, Name = "mar", Amount = "3", Unit = "buc" });
            modelBuilder.Entity<Ingredients>().HasData(
                 new Ingredients { IngredientsId = 2, Name = "ciocolata", Amount = "200", Unit = "g" });
            modelBuilder.Entity<Ingredients>().HasData(
                 new Ingredients { IngredientsId = 3, Name = "lapte", Amount = "500", Unit = "ml" });
            modelBuilder.Entity<Ingredients>().HasData(
                 new Ingredients { IngredientsId = 4, Name = "smantana lichida", Amount = "200", Unit = "ml" });
            modelBuilder.Entity<Ingredients>().HasData(
                 new Ingredients { IngredientsId = 5, Name = "zahar", Amount = "3", Unit = "linguri" });
            modelBuilder.Entity<Ingredients>().HasData(
                 new Ingredients { IngredientsId = 6, Name = "faina", Amount = "150", Unit = "g" });
            modelBuilder.Entity<Ingredients>().HasData(
                 new Ingredients { IngredientsId = 7, Name = "oua", Amount = "2", Unit = "buc" });
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { IngredientsId = 8, Name = "ulei", Amount = "75", Unit = "ml" });
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { IngredientsId = 9, Name = "unt", Amount = "50", Unit = "g" });
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { IngredientsId = 10, Name = "unt de arahide", Amount = "150", Unit = "g" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 11, Name = "lamaie", Amount = "4", Unit = "buc" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 12, Name = "miere", Amount = "150", Unit = "g" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 13, Name = "apa plata", Amount = "1", Unit = "l" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 14, Name = "portocala", Amount = "1-2", Unit = "buc" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 15, Name = "praf de copt", Amount = "1", Unit = "plic" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 16, Name = "esenta de vanilie", Amount = "2", Unit = "lingurite" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 17, Name = "file de somon", Amount = "650", Unit = "g" });
            modelBuilder.Entity<Ingredients>().HasData(
               new Ingredients { IngredientsId = 18, Name = "sare", Amount = "5", Unit = "g" });


            //Seed RecipeIngredient Table
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 1, RecipeId = 1006, IngredientsId = 1 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //    new RecipeIngredient { RecipeIngredientId = 2, RecipeId = 1006, IngredientsId = 2 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //    new RecipeIngredient { RecipeIngredientId = 3, RecipeId = 1007, IngredientsId = 2 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //   new RecipeIngredient { RecipeIngredientId = 4, RecipeId = 1007, IngredientsId = 3 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 5, RecipeId = 1007, IngredientsId = 4 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 6, RecipeId = 1007, IngredientsId = 5 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 7, RecipeId = 1008, IngredientsId = 6 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 8, RecipeId = 1008, IngredientsId = 2 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 9, RecipeId = 1008, IngredientsId = 7 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 10, RecipeId = 1008, IngredientsId = 5 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 11, RecipeId = 1008, IngredientsId = 8 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 12, RecipeId = 1008, IngredientsId = 3 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 13, RecipeId = 1008, IngredientsId = 4 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 14, RecipeId = 1008, IngredientsId = 9 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //  new RecipeIngredient { RecipeIngredientId = 15, RecipeId = 1008, IngredientsId = 10 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            // new RecipeIngredient { RecipeIngredientId = 16, RecipeId = 1009, IngredientsId = 11 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //new RecipeIngredient { RecipeIngredientId = 17, RecipeId = 1009, IngredientsId = 12 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //new RecipeIngredient { RecipeIngredientId = 18, RecipeId = 1009, IngredientsId = 13 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 19, RecipeId = 1010, IngredientsId = 14 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 20, RecipeId = 1010, IngredientsId = 8 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 21, RecipeId = 1010, IngredientsId = 6 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 22, RecipeId = 1010, IngredientsId = 15 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 23, RecipeId = 1010, IngredientsId = 3 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 24, RecipeId = 1010, IngredientsId = 7 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //     new RecipeIngredient { RecipeIngredientId = 25, RecipeId = 1010, IngredientsId = 16 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //    new RecipeIngredient { RecipeIngredientId = 26, RecipeId = 1011, IngredientsId = 17 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //    new RecipeIngredient { RecipeIngredientId = 27, RecipeId = 1011, IngredientsId = 18 });
            // modelBuilder.Entity<RecipeIngredient>().HasData(
            //    new RecipeIngredient { RecipeIngredientId = 28, RecipeId = 1011, IngredientsId = 9 });


        }
    }
}
