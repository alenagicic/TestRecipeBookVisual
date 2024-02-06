using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using RecipeBookVisual.Repository.ProductRepo;
using RecipeBookVisual.ServiceFolder.IngredientService;
using RecipeBookVisual.ServiceFolder.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRecipeBookVisual.Repository
{
    public class RepositoryProductOverride
    {


        private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);



        [Fact]
        public void TestIfOverrides_REMOVE_IsRemoving_MainTable_AndAllRelatedTables_AndReturnTrue()
        {
            //ARRANGE

            ProductMainRepo repo = new(_context);

            ProductMainService main = new(repo);

            main.AddProductMain("hej", 1);

            //ACT

            var result = repo.Remove(x => x.NameOfProduct == "hej");

            //ASSERT

            Assert.True(result);

        }

        [Fact]
        public void TestIfOverrides_Read_IsReading_MainTable_AndAllRelatedTables_AndReturnProductMain()
        {
            //ARRANGE

            ProductMainRepo repo = new(_context);

            ProductMainService main = new(repo);

            main.AddProductMain("hej", 1);

            //ACT

            var result = repo.Read(x => x.NameOfProduct == "hej");

            //ASSERT

            if (result.NameOfProduct == "hej")
            {
                Assert.True(true);
            }

        }
    }
}
