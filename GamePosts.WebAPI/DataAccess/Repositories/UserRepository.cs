using DataAccess.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GamePostsDbContext _context;

        public UserRepository(GamePostsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Guid> AddUser(User user)
        {
            UserEntity userEntity = new UserEntity
            {
                id = Guid.NewGuid(),
                userName = user.userName,
                password = user.password,
                email = user.email,
                phone = user.phone,
                isAdmin = user.isAdmin,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return user.id;
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            await _context.Users.Where(u => u.id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersEntity = await _context.Users.AsNoTracking().ToListAsync();
            var usersList = usersEntity.Select(u => User.UserCreate(u.id, u.userName, u.password, u.email, u.phone, u.isAdmin).user).ToList();
            return usersList;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var userEntity = await _context.Users.AsNoTracking().Where(u => u.id == id).ToListAsync();
            var user = userEntity.Select(u => User.UserCreate(u.id, u.userName, u.password, u.email, u.phone, u.isAdmin).user).First();
            return user;
        }

        public async Task<Guid> UpdateUser(Guid id, string userName, string password, string email, string phone, bool isAdmin)
        {
            await _context.Users.Where(u => u.id == id).ExecuteUpdateAsync(nu => nu
            .SetProperty(u => u.userName, u => userName)
            .SetProperty(u => u.password, u => password)
            .SetProperty(u => u.email, u => email)
            .SetProperty(u => u.phone, u => phone)
            .SetProperty(u => u.isAdmin, u => isAdmin));

            return id;
        }
    }
}
