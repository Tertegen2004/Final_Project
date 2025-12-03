using EduAll.Domain;


namespace EduAll.Repository
{
    public interface IUniteOfWork
    {
        IRepository<Course> Course { get; }
        IRepository<Quiz> Quiz { get; }
        IRepository<AppUser> Instructor { get; }
        IRepository<Section> Section { get; }
        IRepository<Question> Question { get; }
        IRepository<AnswerOption> AnswerOption { get; }
        IRepository<Lesson> Lesson { get; }
        IRepository<AppUser> Student { get; }
        IRepository<Enrollment> Enrollment { get; }
        IRepository<Category> Category { get; }
        IRepository<Wishlist> Wishlist { get; }
    }
}