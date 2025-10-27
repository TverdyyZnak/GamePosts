using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IGameInfoRepository gameInfoRepository { get; }
        ICreatorRepository creatorRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
