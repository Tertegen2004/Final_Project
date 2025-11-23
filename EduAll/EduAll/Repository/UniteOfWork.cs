using EduAll.Data;

namespace EduAll.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly AppDbContext context;

        public UniteOfWork(AppDbContext context)
        {
            this.context = context;
        }
    }
}
