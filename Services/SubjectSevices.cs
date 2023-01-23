using NP.DTOs.Subject;
using NP.Models;
using NP.Data;
using Microsoft.EntityFrameworkCore;
namespace NP.Services
{
    public class SubjectSevices : ISubjectServices
    {
        private readonly DataContext _dataContext;
        public SubjectSevices(DataContext dataContext)
        { 
            _dataContext = dataContext;
        }
        public async Task<Subject> Add(Subject req)
        {
            await _dataContext.Subjects.AddAsync(req);
            await _dataContext.SaveChangesAsync();
            var res = await _dataContext.Subjects.FindAsync(req.Id);
            return res;
        }

        public async Task<Subject> Delete(int id)
        {
            var res = await _dataContext.Subjects.FindAsync(id);
            if(res == null)
            {
                return null;
            }
            _dataContext.Subjects.Remove(res);
            await _dataContext.SaveChangesAsync();
            return res;
            
        }

        public async Task<Subject> Get(int id)
        {
             var res = await _dataContext.Subjects.FindAsync(id);
            if(res == null)
            {
                return null;
            }
           
            return res;
        }

        public async Task<List<Subject>> GetAll()
        {
            return await _dataContext.Subjects.ToListAsync();
        }

        public async Task<Subject> Update(int id,Subject req)
        {
            var res = await _dataContext.Subjects.FindAsync(id);
            if(res == null){
                return null;
            }
            res.ClassID = req.ClassID;
            res.Name = req.Name;
            await _dataContext.SaveChangesAsync();
            return res;
        }
    }
}