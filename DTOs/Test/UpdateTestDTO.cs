namespace NP.DTOs.Test
{
    public class UpdateTestDTO
    {
    
        public string Name { get; set; }
        public int TotalMarks {get;set;}
        public int SubjectId { get; set; }       
       
        public DateTime DateTime {get;set;} = DateTime.Now;
        
       
    }
}