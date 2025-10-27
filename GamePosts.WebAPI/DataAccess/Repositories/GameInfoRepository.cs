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
    public class GameInfoRepository : IGameInfoRepository
    {
        private readonly GamePostsDbContext _context;
        public GameInfoRepository(GamePostsDbContext context)
        {
            _context = context;
        }

        public async Task<List<GameInfo>> GetAllGamesInfo()
        {
            var gameInfoEntities = await _context.GamesInfo.AsNoTracking().ToListAsync();
            var gamesInfoList = gameInfoEntities.Select(g => GameInfo.GameInfoCreate(g.id, g.name, g.description, g.date, g.creatorID, g.stat, g.image, g.downloads).gameInfo).ToList();
            return gamesInfoList;
        }

        public async Task<GameInfo> GetGameInfoByID(Guid id)
        {
            var gameInfoEntity = await _context.GamesInfo.AsNoTracking().Where(g => g.id == id).ToListAsync();
            var gameInfo = gameInfoEntity.Select(g => GameInfo.GameInfoCreate(g.id, g.name, g.description, g.date, g.creatorID, g.stat, g.image, g.downloads).gameInfo).First();
            return gameInfo;
        }

        public async Task<List<GameInfo>> GetAllGamesInfoByCreatorId(Guid id)
        {
            var gameInfoEntity = await _context.GamesInfo.AsNoTracking().Where(g => g.creatorID == id).ToListAsync();
            List<GameInfo> gameInfo = gameInfoEntity.Select(g => GameInfo.GameInfoCreate(g.id, g.name, g.description, g.date, g.creatorID, g.stat, g.image, g.downloads).gameInfo).ToList();
            return gameInfo;
        }

        public async Task<Guid> AddGameInfo(GameInfo gameInfo)
        {
            GameInfoEntity gameInfoEntity = new GameInfoEntity 
            {
                id = Guid.NewGuid(),
                name = gameInfo.name,
                description = gameInfo.description,
                date = gameInfo.date,
                creatorID = gameInfo.creatorID,
                stat = gameInfo.stat,
                image = gameInfo.image,
                downloads = gameInfo.downloads,
            };

            await _context.GamesInfo.AddAsync(gameInfoEntity);
            await _context.SaveChangesAsync();

            return gameInfoEntity.id;
        }

        public async Task<Guid> DeleteGameInfo(Guid id)
        {
            await _context.GamesInfo.Where(g => g.id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<Guid> UpdateGameInfo(Guid id, string name, string description, DateTime date, Guid creatorID, double stat, byte[] image, int downloads)
        {
            await _context.GamesInfo.Where(g => g.id == id).ExecuteUpdateAsync(ng => ng
            .SetProperty(g => g.name, g => name)
            .SetProperty(g => g.description, g => description)
            .SetProperty(g => g.date, g => date)
            .SetProperty(g => g.creatorID, g => creatorID)
            .SetProperty(g => g.stat, g => stat)
            .SetProperty(g => g.image, g => image)
            .SetProperty(g => g.downloads, g => downloads));

            return id;
        }

    }
}
