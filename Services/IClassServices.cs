using NP.Models;
namespace NP.Services
{
    public interface IClassServices
    {
         Task<List<Class>> GetAll();

         Task<Class> Get(int id);

         Task<Class> Add(Class req);

         Task<Class> Update(int id,Class req);

         Task<Class> Delete(int id);
    }
}