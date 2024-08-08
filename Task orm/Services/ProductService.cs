using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Task_orm.Contex;
using Task_orm.Models;

namespace ConsoleAppWithEFCore.Services
{
    public class ProductService
    {
        

       

        public async Task<List<Product>>  GetAllAsync()
        {

            AppDbContex contexts = new AppDbContex();
            var products = await contexts.Products.Include(p => p.Catagory).AsNoTracking().ToListAsync();
            return products;
        }

        public async Task<Product>  GetByIdAsync(int id)
        {
            AppDbContex contexts = new AppDbContex();

            var product =  await contexts.Products.FirstOrDefaultAsync(p=>p.Id== id);
            if (product == null)
            {
                throw new Exception($"bu id tapilmadi{product.Id}");

            }
            return product;

        }

        public async Task CreateAsync(Product product)
        {
            AppDbContex contexts = new AppDbContex();

            contexts.Products.AddAsync(product);
            contexts.SaveChanges();
        }

        public async Task UpdateAsync(Product product)
        {
            AppDbContex contexts = new AppDbContex();

            var dbProduct = await contexts.Products.Include(p=>p.Catagory).FirstOrDefaultAsync(p=>p.Id==product.Id);
           if (dbProduct == null)
            {
                throw new Exception($"bu id tapilmadi{product.Id}");
                

            }
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Catagory.Name = product.Catagory.Name;
            contexts.Products.Update(product);
            contexts.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            AppDbContex contexts = new AppDbContex();
            var product = await contexts.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new Exception($"bu id tapilmadi{product.Id}");
            }
                contexts.Products.Remove(product);
                contexts.SaveChanges();
        }
    }
}
