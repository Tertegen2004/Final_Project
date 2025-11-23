using EduAll.Constant;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class CourseSuggestion
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public SuggestionState Status { get; set; } = SuggestionState.Pending;

        public string? AdminResponseNote { get; set; }
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
