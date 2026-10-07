using System.ComponentModel.DataAnnotations;

namespace lamia12771.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        public string Office { get; set; }

        public string Title { get; set; }

        public string About { get; set; }

        public string Education { get; set; }

        public string AcademicExperience { get; set; }

        public string ResearchInterests { get; set; }

        public string CoursesTaught { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ImagePath { get; set; }
    }
}