using NP.Data;
using NP.Models;
using NP.DTOs.StudentClass;
using Microsoft.EntityFrameworkCore;
namespace NP.Services
{
    public class StudentServices : IStudentServices
    {
       private readonly DataContext _dataContext;
       
       public StudentServices(DataContext dataContext)
       {
        this._dataContext = dataContext;
       }
        public async Task<Student> Add(Student req)
        {
            await _dataContext.Students.AddAsync(req);
            await _dataContext.SaveChangesAsync();
            var res = await _dataContext.Students.FindAsync(req.Id);
            return res;
        }

        public async Task<Student> Delete(int id)
        {
            var res = await _dataContext.Students.FindAsync(id);
            if(res == null){
                return null;
            }
            _dataContext.Students.Remove(res);
            await _dataContext.SaveChangesAsync();
            return res;
        }

        public async Task<Student> Get(int id)
        {
           var res = await _dataContext.Students.FindAsync(id);
           return res;
        }

        public async Task<List<Student>>GetAll()
        {
            return await _dataContext.Students.ToListAsync();
        }

        public async Task<Student> Update(int id, Student req)
        {
            var res = await _dataContext.Students.FindAsync(id);
            if(res ==null){
                return null;
            }
            res.Name = req.Name;
            await _dataContext.SaveChangesAsync();
            return res;
        }

        public async Task<Student> AddClass(AddStudentClassDTO req){
            var student = await _dataContext.Students
                            .Include(x=>x.Classes)
                            .FirstOrDefaultAsync(x=>x.Id == req.StudentId);

            var classobj = await _dataContext.Classes.FindAsync(req.ClassId);

            student.Classes.Add(classobj);

            await _dataContext.SaveChangesAsync();

            return student;
        }


        public async Task<Student> GetClass(int id){
            var res = await _dataContext.Students.Include(x=>x.Classes).FirstOrDefaultAsync(x=>x.Id == id);
            return res;
        }

        public async Task<Student> RemoveClass(RemoveStudentClassDTO req){
            var student = await _dataContext.Students
                            .Include(x=>x.Classes)
                            .FirstOrDefaultAsync(x=>x.Id == req.StudentId);

            var resIndex = student.Classes.FindIndex(x=>x.Id == req.ClassId);
            if(resIndex !=-1){
                student.Classes.Remove(student.Classes[resIndex]);
                await _dataContext.SaveChangesAsync();
                return student;
            }
            return null;


        }
    }

}