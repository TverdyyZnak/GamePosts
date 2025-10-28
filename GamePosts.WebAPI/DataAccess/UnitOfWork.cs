using DataAccess.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GamePostsDbContext _context;


        public IGameInfoRepository gameInfoRepository { get; }
        public ICreatorRepository creatorRepository { get; }
        public IUserRepository userRepository { get; }


        public UnitOfWork(GamePostsDbContext dbContext)
        {
            _context = dbContext;
            gameInfoRepository = new GameInfoRepository(dbContext);
            creatorRepository = new CreatorRepository(dbContext);
            userRepository = new UserRepository(dbContext);            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
