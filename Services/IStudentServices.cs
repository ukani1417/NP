using NP.Models;
namespace NP.Services
{
    public interface IStudentServices
    {
         Task<List<Student>> GetAll();
         Task<Student> Get(int id);

         Task<Student> Add(Student req);

         Task<Student> Update(int id,Student req);

         Task<Student> Delete(int id);
    }
}