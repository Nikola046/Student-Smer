namespace Student_Smer.Models
{
    public class StudentListView
    {
        public string Filter { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
