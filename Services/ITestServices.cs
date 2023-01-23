using NP.Models;
namespace NP.Services
{
    public interface ITestServices
    {
        Task<List<Test>> GetAll();

         Task<Test> Get(int id);

         Task<Test> Add(Test req);

         Task<Test> Update(int id,Test req);

         Task<Test> Delete(int id);


    }
}