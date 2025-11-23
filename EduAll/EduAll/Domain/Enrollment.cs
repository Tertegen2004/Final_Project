using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int Progress { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.Now;
        public DateTime LastAccessed { get; set; }

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
