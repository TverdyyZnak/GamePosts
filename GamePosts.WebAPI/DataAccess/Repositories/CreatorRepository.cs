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
    public class CreatorRepository : ICreatorRepository
    {
        private readonly GamePostsDbContext _context;

        public CreatorRepository(GamePostsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Guid> AddCreator(Creator creator)
        {
            CreatorEntity entity = new CreatorEntity 
            {
                id = Guid.NewGuid(),
                name = creator.name,
                description = creator.description,
                gamesCount = creator.gamesCount,
                date = creator.date,
                director = creator.director,
                companyImage = creator.companyImage,
            };

            await _context.Creators.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.id;
        }

        public async Task<Guid> DeleteCreator(Guid id)
        {
            await _context.Creators.Where(c => c.id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<Creator>> GetAllCreators()
        {
            var creatorsEntity = await _context.Creators.AsNoTracking().ToListAsync();
            var creatorsList = creatorsEntity.Select(c => Creator.CreatorCreate(c.id, c.name, c.description, c.gamesCount, c.date, c.director, c.companyImage).creator).ToList();
            return creatorsList;
        }

        public async Task<Creator> GetCreatorById(Guid id)
        {
            var creatorEntity = await _context.Creators.AsNoTracking().Where(c => c.id == id).ToListAsync();
            return creatorEntity.Select(c => Creator.CreatorCreate(c.id, c.name, c.description, c.gamesCount, c.date, c.director, c.companyImage).creator).First();
        }

        public async Task<Guid> UpdateCreator(Guid id, string name, string description, int gamesCount, DateTime date, string director, byte[] companyImage)
        {
            await _context.Creators.Where(c => c.id == id).ExecuteUpdateAsync(nc => nc
            .SetProperty(c => c.name, c => name)
            .SetProperty(c => c.description, c => description)
            .SetProperty(c => c.gamesCount, c => gamesCount)
            .SetProperty(c => c.date, c => date)
            .SetProperty(c => c.director, c => director)
            .SetProperty(c => c.companyImage, c => companyImage));

            return id;
        }
    }
}
