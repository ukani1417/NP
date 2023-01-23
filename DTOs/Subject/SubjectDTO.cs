
namespace NP.DTOs.Subject
{
    public class SubjectDTO
    {
        public int Id { get; set; }

        public string Name {get ;set;}

        public int  ClassID { get; set; }
        public Models.Class Class { get; set; }

         public List<Models.Test> Tests { get; set; }

    }
}