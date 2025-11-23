using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // FK
        public string UserId { get; set; }
        public int CourseId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }


    }
}
