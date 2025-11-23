using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class QuizSubmission
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public bool IsPassed { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        // Fk
        public string StudentId { get; set; }
        public int QuizId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(StudentId))]
        public AppUser Student { get; set; }

        [ForeignKey(nameof(QuizId))]
        public Quiz Quiz { get; set; }

        public List<StudentAnswer> StudentAnswers { get; set; }
    }
}
