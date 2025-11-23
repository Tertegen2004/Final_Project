using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }

        // FK
        public int QuizId { get; set; }
        // Nav Prop
        [ForeignKey(nameof(QuizId))]
        public Quiz Quiz { get; set; }

        public List<AnswerOption> Options { get; set; }
    }
}
