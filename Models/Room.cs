using System.ComponentModel.DataAnnotations;

namespace lamia12771.Models
{
    public class Room
    {
        public int RoomId { get; set; }


        [Required]
        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }


        [Required]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }


        [Required]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }


        [Range(1, 1000)]
        public int Capacity { get; set; }


        [Range(0, 100000)]
        [Display(Name = "Area")]
        public int Area { get; set; }


        [Required]
        public string Status { get; set; }


        public string Description { get; set; }


        public string Facilities { get; set; }


        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    }
}