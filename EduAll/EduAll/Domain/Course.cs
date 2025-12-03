using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Level { get; set; }
        public string Language { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Duration { get; set; }

        // FK
        public string InstructorId { get; set; }
        public int CategoryId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(InstructorId))]
        public AppUser Instructor { get; set; }
        [ForeignKey(nameof(CategoryId))]

        public Category Category { get; set; }

        public List<Section> Sections { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
