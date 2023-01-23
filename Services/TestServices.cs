using NP.Models;
using NP.Data;
using Microsoft.EntityFrameworkCore;
namespace NP.Services

{
    public class TestServices : ITestServices
    {
         private readonly DataContext _dataContext;
        public TestServices(DataContext dataContext)
        { 
            _dataContext = dataContext;
        }
        public async Task<Test> Add(Test req)
        {
            await _dataContext.Tests.AddAsync(req);
            await _dataContext.SaveChangesAsync();
            var res = await _dataContext.Tests.FindAsync(req.Id);
            return res;
        }

        public async Task<Test> Delete(int id)
        {
            var res = await _dataContext.Tests.FindAsync(id);
            if(res == null)
            {
                return null;
            }
            _dataContext.Tests.Remove(res);
            await _dataContext.SaveChangesAsync();
            return res;
            
        }

        public async Task<Test> Get(int id)
        {
             var res = await _dataContext.Tests.FindAsync(id);
            if(res == null)
            {
                return null;
            }
           
            return res;
        }

        public async Task<List<Test>> GetAll()
        {
            return await _dataContext.Tests.ToListAsync();
        }

        public async Task<Test> Update(int id,Test req)
        {
            var res = await _dataContext.Tests.FindAsync(id);
            if(res == null){
                return null;
            }
            res.Name = req.Name;
            res.TotalMarks = req.TotalMarks;
            res.SubjectId = req.SubjectId;
            res.DateTime = req.DateTime;
            await _dataContext.SaveChangesAsync();
            return res;
        }
    }
}