using NP.Models;
using NP.DTOs.Subject;
namespace NP.Services
{
    public interface ISubjectServices
    {
         Task<Subject> Add(Subject req);
         Task<Subject> Get(int id);

         Task<List<Subject>> GetAll();

         Task<Subject> Update(int id,Subject req);

         Task<Subject> Delete(int id);
    }
}