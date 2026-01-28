namespace demo.api.Models
{
    public class Student
    {
        public Nullable<int> studId { get; set; }
        public string mobileNo { get; set; } = string.Empty;

        public bool isActive { get; set; }

        public Nullable<DateTime> startDate { get; set; } 
    }
}
