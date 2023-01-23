namespace NP.DTOs.Test
{
    public class TestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalMarks {get;set;}

        public DateTime DateTime {get;set;} = DateTime.Now;
        
        
        public int SubjectId { get; set; }
        public Models.Subject Subject { get; set; }
    }
}