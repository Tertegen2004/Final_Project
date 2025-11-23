using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PassingScore { get; set; }

        // FK
        public int SectionId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }

        public List<Question> Questions { get; set; }
        public List<QuizSubmission> Submissions { get; set; }

    }
}
