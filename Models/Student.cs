using System.ComponentModel.DataAnnotations;

namespace lamia12771.Models
{
    public class Student
    {
        public int StudentId { get; set; }


        [Required]
        public string Name { get; set; }


        public int Age { get; set; }


        [Required]
        public string Major { get; set; }


        [Required]
        public string Level { get; set; }


        [Required]
        [Display(Name = "GPA")]
        public decimal GPA { get; set; }


        [Display(Name = "Credits Completed")]
        public int CreditsCompleted { get; set; }


        [Display(Name = "Degree Progress")]
        public int DegreeProgress { get; set; }


        [Display(Name = "Academic Standing")]
        public string AcademicStanding { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Image")]
        public string ImagePath { get; set; }


        // Academic Advisor
        [Display(Name = "Academic Advisor")]
        public int? TeacherId { get; set; }


        public virtual Teacher Teacher { get; set; }
    }
}