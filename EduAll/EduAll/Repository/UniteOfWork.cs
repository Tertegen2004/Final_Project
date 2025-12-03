using EduAll.Data;
using EduAll.Domain;

namespace EduAll.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly AppDbContext context;

        public UniteOfWork(AppDbContext context)
        {
            this.context = context;
            Course = new Repository<Course>(context);
            Instructor = new Repository<AppUser>(context);
            Section = new Repository<Section>(context);
            Quiz = new Repository<Quiz>(context);
            Question = new Repository<Question>(context);
            Lesson = new Repository<Lesson>(context);
            AnswerOption = new Repository<AnswerOption>(context);
            Category = new Repository<Category>(context);
            Student = new Repository<AppUser>(context);
            Enrollment = new Repository<Enrollment>(context);
            Wishlist = new Repository<Wishlist>(context);
        }

        public IRepository<Course> Course { get; }
        public IRepository<AppUser> Instructor { get; }
        public IRepository<Section> Section { get; }
        public IRepository<Quiz> Quiz { get; }
        public IRepository<Question> Question { get; }
        public IRepository<AnswerOption> AnswerOption { get; }
        public IRepository<Lesson> Lesson { get; }
        public IRepository<AppUser> Student { get; }
        public IRepository<Enrollment> Enrollment { get; }
        public IRepository<Category> Category { get; }
        public IRepository<Wishlist>Wishlist { get; }
    }
}