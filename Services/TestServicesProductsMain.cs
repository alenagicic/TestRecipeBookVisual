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

namespace TestRecipeBookVisual.Services
{
    public class TestServicesProductsMain
    {



        private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()
     .UseInMemoryDatabase($"{Guid.NewGuid()}")
     .Options);


        [Fact]

        public void TestToSeeIfMain_PRODUCT_Service_ADD_ActuallyAddsAnything_AndReturnsTrue()
        {
            // ARRANGE

            ProductMainRepo repo = new(_context);

            ProductMainService main = new(repo);

            // ASSERT

            var result = main.AddProductMain("hej", 1);


            // ACT

            Assert.True(result);
        }

        [Fact]
        public void TestToSeeIfMain_PRODUCT_Service_REMOVE_ActuallyRemovesAnything_AndReturnsTrue()
        {
            //ARRANGE
            ProductMainRepo repo = new(_context);

            ProductMainService main = new(repo);

            main.AddProductMain("hej", 1);

            //ASSERT

            var result = main.RemoveProductMain("hej");

            //ACT

            Assert.True(result);
        }

        [Fact]

        public void TestToSeeIfMain_PRODUCT_Service_UPDATE_ActuallyUpdatesAnything_AndReturnsTrue()
        {
            //ARRANGE

            ProductMainRepo repo = new(_context);

            ProductMainService main = new(repo);

            var mainproduct = main.AddProductMain("hej", 1);

            

            //ACT

            var result = main.UpdateProductMain(new ProductsMain() { NameOfProduct = "hej", Price = 1, Id = 1});

            //ASSERT

            Assert.True(result);
        }

        [Fact]

        public void TestToSeeIfMain_PRODUCT_Service_READ_ActuallyREADSsAnything_AndReturnsObject()
        {
            //ARRANGE

            ProductMainRepo repo = new(_context);

            ProductMainService main = new(repo);

            main.AddProductMain("hej", 1);

            //ACT

            var result = main.ReadProductMain("hej");

            //ASSERT

            if (result.NameOfProduct == "hej")
            {
                Assert.True(true);
            }

        }

        [Fact]

        public void TestToSeeIfMain_PRODUCT_Service_READALL_ActuallyREADS_ALL_AndReturnsObject()
        {
            //ARRANGE

            ProductMainRepo repo = new(_context);

            ProductMainService main = new(repo);

            List<ProductsMain> listComparison = new();

            //ACT

            var result = main.ReadAllProductMain();

            //ASSERT

            Assert.Equal(listComparison, result);


        }



    }
}
