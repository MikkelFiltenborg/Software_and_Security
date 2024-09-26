using Microsoft.EntityFrameworkCore;
using SoftwareTest_and_Security.Interface;
using SoftwareTest_and_Security.Models;
using System.ComponentModel.DataAnnotations;

namespace SoftwareTest_and_Security.Repo
{
    public class CprRepo : ICRUD<CprNr>
    {
        ToDoContext context;

        public CprRepo(ToDoContext temp)
        {
            context = temp;
        }

        public async Task AddItemToList(CprNr model, ToDo item)
        {
            if (model.toDoList == null)
            {
                model.toDoList = new List<ToDo>();
            }

            model.toDoList.Add(item);
            await context.SaveChangesAsync();
            return;
        }

        public async Task<CprNr> Create(CprNr model)
        {
            context.CprNr.Add(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<List<CprNr>> GetAll()
        {
            return await context.CprNr.Include(param => param.toDoList).ToListAsync();
        }

        public async Task<CprNr> GetById(int id)
        {
            return await context.CprNr.FirstAsync(x => x.Id == id);
        }

        public async Task<CprNr?> Update(CprNr model)
        {
            throw new NotImplementedException();
        }

        public async Task<CprNr> Delete(int id)
        {
            CprNr cprNr = await GetById(id);
            if (cprNr != null)
            {
                context.CprNr.Remove(cprNr);
                await context.SaveChangesAsync();
            }
            return cprNr;
        }
    }
}
