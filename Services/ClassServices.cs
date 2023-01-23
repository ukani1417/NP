using NP.Data;
using NP.Models;
using Microsoft.EntityFrameworkCore;
namespace NP.Services
{
    public class ClassServices : IClassServices
    {
        private readonly DataContext _dataContext ;

        public ClassServices(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<Class> Add(Class req)
        {
            if(req == null){
                return req;
            }
            
            await _dataContext.AddAsync(req);
            await _dataContext.SaveChangesAsync();
            var res =  await _dataContext.Classes.FindAsync(req.Id); 
            return res;
        }

        public async  Task<Class> Delete(int id)
        {
            var req = await _dataContext.Classes.FindAsync(id);
            if(req == null){
                return null;
            }
            _dataContext.Classes.Remove(req);
           await _dataContext.SaveChangesAsync();
            return req;
        }

        public async Task<Class> Get(int id)
        {
            var req =  await _dataContext.Classes.FindAsync(id);
            return req ;            
        }

        public async Task<List<Class>> GetAll()
        {
            return  await _dataContext.Classes.ToListAsync();
        }

        public async Task<Class> Update(int id, Class req)
        {
            var res = await _dataContext.Classes.FindAsync(id);
            if(res == null){
                return null;
            }
            res.Number  = req.Number;
            await _dataContext.SaveChangesAsync();
            return res;
        }
    }
}