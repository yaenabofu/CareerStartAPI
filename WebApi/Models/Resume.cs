namespace WebApi.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Description { get; set; }
        public string IsVisible { get; set; }
    }
}
