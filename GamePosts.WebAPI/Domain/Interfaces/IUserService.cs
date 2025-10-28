using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<Guid> AddUser(User user);
        Task<Guid> DeleteUser(Guid id);
        Task<Guid> UpdateUser(Guid id, string userName, string password, string email, string phone, bool isAdmin);
    }
}
