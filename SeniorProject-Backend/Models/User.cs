namespace SeniorProject_Backend.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public string StudyYear { get; set; }
        public string City { get; set; }
        public int Income { get; set; }
        public string HasSickness { get; set; }
        public string IsUsingMedicine { get; set; }
        public int ProgressLevel { get; set; }
    }
}
