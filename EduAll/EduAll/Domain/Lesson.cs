using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string Duration { get; set; }
        public string? Content { get; set; }
        public int Order { get; set; }


        // FK
        public int SectionId { get; set; }

        [ForeignKey(nameof(SectionId))]

        // Nav Prop
        public Section Section { get; set; }

    }
}
