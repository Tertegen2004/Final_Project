using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        // FK
        public int QuestionId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }
    }
}
