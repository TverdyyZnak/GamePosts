using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGameInfoService
    {
        Task<List<GameInfo>> GetAllGamesInfo();
        Task<GameInfo> GetGameInfoByID(Guid id);
        Task<List<GameInfo>> GetAllGamesInfoByCreatorId(Guid id);
        Task<Guid> AddGameInfo(GameInfo gameInfo);
        Task<Guid> DeleteGameInfo(Guid id);
        Task<Guid> UpdateGameInfo(string name, string description, DateTime date, string creatorID, double stat, byte[] image, int downloads);
    }
}
