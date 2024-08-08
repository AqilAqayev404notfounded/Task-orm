using ConsoleAppWithEFCore.Services;
using Task_orm.Models;
using Task_orm.Services;

namespace Task_orm
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ProductService productService = new ProductService();
            CatagoryService catagoryService = new CatagoryService();

            Catagory catagory = new Catagory { Name= "electronics"};
           await  catagoryService.CreateAsync(catagory);

            Product product = new Product { 
                Name= "iphone",
                Price=3001,
                CatagoryId = catagory.Id
            };

            await productService.UpdateAsync(product);



        }
    }
            
}
