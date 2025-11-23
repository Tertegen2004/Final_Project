using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class StudentAnswer
    {
        public int Id { get; set; }

        // FK

        public int SubmissionId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(SubmissionId))]
        public QuizSubmission Submission { get; set; }
        [ForeignKey(nameof(QuestionId))]

        public Question Question { get; set; }
        [ForeignKey(nameof(SelectedOptionId))]

        public AnswerOption SelectedOption { get; set; }
    }
}
