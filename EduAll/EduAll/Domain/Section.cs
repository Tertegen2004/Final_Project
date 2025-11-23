using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }

        // Fk
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]

        // Nav Prop
        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Quiz> Quizzes { get; set; }

    }
}
