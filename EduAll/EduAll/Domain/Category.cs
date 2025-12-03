namespace EduAll.Domain
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? IconUrl { get; set; }

        public string? Description { get; set; }

        // Nav Prop
        public List<Course> Courses { get; set; } = new();
    }
}

