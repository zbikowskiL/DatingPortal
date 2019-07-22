using System.Threading.Tasks;
using DatingPortal.API.Data;
using DatingPortal.API.Models.Iterfaces;

namespace DatingPortal.API.Models.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext context;
        public GenericRepository(DataContext context)
        {
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}