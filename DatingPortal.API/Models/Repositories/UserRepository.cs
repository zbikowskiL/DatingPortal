using System.Collections.Generic;
using System.Threading.Tasks;
using DatingPortal.API.Data;
using DatingPortal.API.Models.Iterfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingPortal.API.Models.Repositories
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }
    }
}