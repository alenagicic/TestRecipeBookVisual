using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRecipeBookVisual.Repository
{
    public class RepositoryIngredientBase
    {
        private readonly IngredientContext _context = new(new DbContextOptionsBuilder<IngredientContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);


        [Fact]

        public void TestIfRepository_Ingredient_MethodsActually_ADDS_ToDatabase()
        {
            //ARRANGE

            MainRepositoryIngredient<MainRecipe> rep = new(_context);

            MainRecipe main = new() { TitleRecipe = "" };

            //ACT

            var result = rep.Add(main);

            //ASSERT

            Assert.True(result);


        }

        [Fact]
        public void TestIfRepository_Ingredient_MethodsActually_REMOVES_FromDatabase()
        {
            //ARRANGE

            MainRepositoryIngredient<MainRecipe> rep = new(_context);

            MainRecipe main = new() { TitleRecipe = "hej"};

            var add = rep.Add(main);

            //ACT

            var result = rep.Remove(x => x.TitleRecipe == "hej");

            //ASSERT

            Assert.True(result);

        }

        [Fact]

        public void TestIfRepository_Ingredient_MethodsActually_UPDATES_FromDatabase()
        {

            //ARRANGE 

            MainRepositoryIngredient<MainRecipe> rep = new(_context);

            MainRecipe main = new() { TitleRecipe = "hej" };

            var add = rep.Add(main);

            //ACT 

            var result = rep.Update(x => x.TitleRecipe == "hej", main);

            //ASSERT

            Assert.True(result);

        }

        [Fact]
        public void TestIfRepository_Ingredient_MethodsActually_READ_FromDatabase()
        {
            //ARRANGE

            MainRepositoryIngredient<MainRecipe> rep = new(_context);

            MainRecipe main = new MainRecipe() { TitleRecipe = "hej" };

            var add = rep.Add(main);

            //ACT

            var result = rep.Read(x => x.TitleRecipe == "hej");


            //ASSERT

            Assert.Equal(result, main);

        }

        [Fact]

        public void TestIfRepository_Ingredient_MethodsActually_READALL_FromDatabase()
        {
            //ARRANGE

            MainRepositoryIngredient<MainRecipe> rep = new(_context);

            List<MainRecipe> list = new();


            //ACT

            var result = rep.ReadAll();


            //ASSERT

            Assert.Equal(result, list);


        }


    }
}
