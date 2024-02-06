
using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository;

namespace TestRecipeBookVisual.Repository
{
    public class RepositoryProductBase
    {

        private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);


        [Fact]

        public void TestIfRepository_Product_MethodsActually_ADDS_ToDatabase()
        {
            //ARRANGE

            MainRepositoryProduct<ProductsMain> rep = new(_context);

            ProductsMain main = new() { NameOfProduct = "", Price = 1 };

            //ACT

            var result = rep.Add(main);

            //ASSERT

            Assert.True(result);


        }

        [Fact]
        public void TestIfRepository_Product_MethodsActually_REMOVES_FromDatabase()
        {
            //ARRANGE

            MainRepositoryProduct<ProductsMain> rep = new(_context);

            ProductsMain main = new() { NameOfProduct = "hej", Price = 1 };

            var add = rep.Add(main);

            //ACT

            var result = rep.Remove(x => x.NameOfProduct == "hej");

            //ASSERT

            Assert.True(result);

        }

        [Fact]

        public void TestIfRepository_Product_MethodsActually_UPDATES_FromDatabase()
        {

            //ARRANGE 

            MainRepositoryProduct<ProductsMain> rep = new(_context);

            ProductsMain main = new() { NameOfProduct = "hej", Price = 1 };

            var add = rep.Add(main);

            //ACT 

            var result = rep.Update(x => x.NameOfProduct == "hej", main);

            //ASSERT

            Assert.True(result);

        }

        [Fact]
        public void TestIfRepository_Product_MethodsActually_READ_FromDatabase()
        {
            //ARRANGE

            MainRepositoryProduct<ProductsMain> rep = new(_context);

            ProductsMain main = new ProductsMain() {Id = 0, NameOfProduct = "hej", Price = 0 };

            var add = rep.Add(main);

            //ACT

            var result = rep.Read(x => x.NameOfProduct == "hej");


            //ASSERT

            Assert.Equal(result, main);

        }

        [Fact]

        public void TestIfRepository_Product_MethodsActually_READALL_FromDatabase()
        {
            //ARRANGE

            MainRepositoryProduct<ProductsMain> rep = new(_context);

            List<ProductsMain> list = new();


            //ACT

            var result = rep.ReadAll();


            //ASSERT

            Assert.Equal(result, list);


        }


    }



}

