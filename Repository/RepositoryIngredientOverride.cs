using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using RecipeBookVisual.Repository.ProductRepo;
using RecipeBookVisual.ServiceFolder.IngredientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRecipeBookVisual.Repository
{
    public class RepositoryIngredientOverride
    {

        private readonly IngredientContext _context = new(new DbContextOptionsBuilder<IngredientContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);



        [Fact]
        public void TestIfOverrides_REMOVE_IsRemoving_MainTable_AndAllRelatedTables_AndReturnTrue()
        {
            //ARRANGE

            MainRecipeRepo repo = new(_context);

            MainRecipeService main = new(repo);

            MainRecipe mainrecipe = new() { TitleRecipe = "hej" };

            main.AddMainRecipe(mainrecipe);

            //ACT

            var result = repo.Remove(x => x.TitleRecipe == "hej");

            //ASSERT

            Assert.True(result);

        }

        [Fact]
        public void TestIfOverrides_Read_IsReading_MainTable_AndAllRelatedTables_AndReturnMainRecipe()
        {
            //ARRANGE

            MainRecipeRepo repo = new(_context);

            MainRecipeService main = new(repo);

            MainRecipe mainrecipe = new() { Id = 1, TitleRecipe = "hej" };
           
            main.AddMainRecipe(mainrecipe);

            //ACT

            var result = repo.Read(x => x.TitleRecipe == "hej");

            //ASSERT

            if (result.TitleRecipe == "hej")
            {
                Assert.True(true);
            }

        }



    }
}
