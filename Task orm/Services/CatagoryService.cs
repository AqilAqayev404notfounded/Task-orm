using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_orm.Contex;
using Task_orm.Models;

namespace Task_orm.Services
{
    public class CatagoryService
    {


       
        public async Task<List<Catagory>> GetAllAsync()
        {
            AppDbContex contexts = new AppDbContex();
            return await contexts.Catagory.ToListAsync();
        }

        public async Task<Catagory> GetByIdAsync(int id)
        {
            AppDbContex contexts = new AppDbContex();

            var catagory = await contexts.Catagory.FirstOrDefaultAsync(p => p.Id==id);
            if (catagory == null)
            {
                throw new Exception($"bu id tapilmadi: {id}");
            }
            return catagory;
        }

        public async Task CreateAsync(Catagory catagory)
        {
            AppDbContex contexts = new AppDbContex();

            await contexts.Catagory.AddAsync(catagory);
            await contexts.SaveChangesAsync();
        }

        public async Task UpdateAsync(Catagory catagory)
        {
            AppDbContex contexts = new AppDbContex();

            var catagoryexit = await contexts.Catagory.FirstOrDefaultAsync(p => p.Id == catagory.Id);
            if (catagoryexit == null)
            {
                throw new Exception($"bu id tapilmadi: {catagory.Id}");
            }
            catagoryexit.Name = catagory.Name;
            contexts.Catagory.Update(catagoryexit);
            await contexts.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AppDbContex contexts = new AppDbContex();

            var catagory = await contexts.Catagory.FirstOrDefaultAsync(p => p.Id == id);
            if (catagory == null)
            {
                throw new Exception($"bu id tapilmadi: {id}");
            }
            contexts.Catagory.Remove(catagory);
            await contexts.SaveChangesAsync();
        }
    }
}
