namespace NP.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name {get ;set;}

        public int  ClassID { get; set; }
        public Class Class { get; set; }

        public List<Test> Tests { get; set; }
    }
}