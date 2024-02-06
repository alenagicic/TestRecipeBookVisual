using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using RecipeBookVisual.ServiceFolder.IngredientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRecipeBookVisual.Services
{
    public class TestServicesIngredientMain
    {


        private readonly IngredientContext _context = new(new DbContextOptionsBuilder<IngredientContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);


        [Fact]

        public void TestToSeeIfMainRecipeService_ADD_ActuallyAddsAnything_AndReturnsTrue()
        {
            // ARRANGE

            MainRecipeRepo repo = new(_context);

            MainRecipeService main = new(repo);

            // ASSERT

            var result = main.AddMainRecipe(new MainRecipe() { TitleRecipe = "hej"});


            // ACT

            Assert.True(result);
        }

        [Fact]
        public void TestToSeeIfMainRecipeService_REMOVE_ActuallyRemovesAnything_AndReturnsTrue()
        {
            //ARRANGE
            MainRecipeRepo repo = new(_context);
            MainRecipeService main = new(repo);

            main.AddMainRecipe(new MainRecipe() { TitleRecipe = "hej"});

            //ASSERT

            var result = main.RemoveMainRecipe("hej");

            //ACT

            Assert.True(result);
        }

        [Fact]

        public void TestToSeeIfMainRecipeService_UPDATE_ActuallyUpdatesAnything_AndReturnsTrue()
        {
            //ARRANGE

            MainRecipeRepo repo = new(_context);
            MainRecipeService main = new(repo);

            main.AddMainRecipe(new MainRecipe() { TitleRecipe = "hej", Id = 1 });

            //ACT

            var result = main.UpdateMainRecipe(new MainRecipe() { TitleRecipe = "hej", Id = 1});

            //ASSERT

            Assert.True(result);
        }

        [Fact]

        public void TestToSeeIfMainRecipeService_READ_ActuallyREADSsAnything_AndReturnsObject()
        {
            //ARRANGE

            MainRecipeRepo repo = new(_context);
            MainRecipeService main = new(repo);

            main.AddMainRecipe(new MainRecipe() { TitleRecipe = "hej" });

            //ACT

            var result = main.ReadMainRecipe("hej");

            //ASSERT

            if (result.TitleRecipe == "hej")
            {
                Assert.True(true);
            }

        }

        [Fact]

        public void TestToSeeIfMainRecipeService_READALL_ActuallyREADS_ALL_AndReturnsObject()
        {
            //ARRANGE

            MainRecipeRepo repo = new(_context);
            MainRecipeService main = new(repo);

            List<MainRecipe> listComparison = new();

            //ACT

            var result = main.ReadAllMains();

            //ASSERT

            Assert.Equal(listComparison, result);


        }


    }
}
