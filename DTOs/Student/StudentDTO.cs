
using NP.Models;
namespace NP.DTOs.Student
{
    public class StudentDTO
    {
         public int Id { get; set; }
         public string Name { get; set; }  = string.Empty;

         public List<Models.Class> Classes { get; set; }
    }
}