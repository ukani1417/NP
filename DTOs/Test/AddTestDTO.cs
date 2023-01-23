namespace NP.DTOs.Test
{
    public class AddTestDTO
    {   
        public string Name { get; set; }

        public int TotalMarks {get;set;}

        
        public int SubjectId { get; set; }
       
      
        public DateTime DateTime {get;set;} = DateTime.Now;
        
        
    }
}