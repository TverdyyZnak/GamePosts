using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICreatorRepository
    {
        Task<List<Creator>> GetAllCreators();
        Task<Creator> GetCreatorById(Guid id);
        Task<Guid> AddCreator(Creator creator);
        Task<Guid> DeleteCreator(Guid id);
        Task<Guid> UpdateCreator(Guid id, string name, string description, int gamesCount, DateTime date, string director, byte[] companyImage);
    }
}
