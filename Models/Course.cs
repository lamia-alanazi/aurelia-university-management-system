using System.ComponentModel.DataAnnotations;

namespace lamia12771.Models
{
    public class Course
    {
        public int CourseId { get; set; }


        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }


        [Required]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }


        [Required]
        public string Category { get; set; }


        [Range(1, 10)]
        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }


        public string Schedule { get; set; }


        public string Location { get; set; }


        public string Description { get; set; }


        public string Topics { get; set; }


        [Display(Name = "Image")]
        public string ImagePath { get; set; }


        // =========================================================
        // OLD INSTRUCTOR FIELD
        // Keep temporarily so existing course data is not affected
        // =========================================================

        public string Instructor { get; set; }


        // =========================================================
        // TEACHER RELATION
        // One Course -> One Teacher
        // One Teacher -> Many Courses
        // =========================================================

        [Display(Name = "Instructor")]
        public int? TeacherId { get; set; }


        public virtual Teacher Teacher { get; set; }
    }
}