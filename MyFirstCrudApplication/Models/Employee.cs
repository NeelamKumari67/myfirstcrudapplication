using System.ComponentModel.DataAnnotations;

namespace MyFirstCrudApplication.Models
{
    public class Employee
    {
        
        public int Employee_Id { get;}
        [Required]
        public string? Employee_Name { get; set; }
        [Required]
        public int Employee_PhoneNumber { get; set; }
        [Required]
        public string? Employee_Email { get; set; }
        [Required]
        public DateOnly Hire_Date{ get; set; }
        [Required]
        public string? Status{ get; set; }
        [Required]
        public string? Title { get; set; }

    }
}
