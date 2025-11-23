using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EduAll.Domain
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Country { get; set; }
        [Required]
        public string? ImgUrl { get; set; }
        public string? JobTitle { get; set; }
        public string? Bio { get; set; }
        [Url]
        public string? FaceBookUrl { get; set; }
        [Url]
        public string? InstagramUrl { get; set; }
        [Url]
        public string? TwitterUrl { get; set; }
        [Url]
        public string? GmailUrl { get; set; }

        // Nav Prop
        public List<Course> CoursesCreated { get; set; } // For Instructors
        public List<Enrollment> Enrollments { get; set; } // For Students
        public  Cart Cart { get; set; }
    }
}
