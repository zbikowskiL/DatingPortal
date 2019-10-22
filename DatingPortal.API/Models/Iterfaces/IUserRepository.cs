using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingPortal.API.Models.Iterfaces
{
    public interface IUserRepository : IGenericRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<Photo> GetPhoto(int id);
    }
}