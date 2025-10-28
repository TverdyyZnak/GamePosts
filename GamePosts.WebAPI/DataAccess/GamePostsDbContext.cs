using DataAccess.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GamePostsDbContext : DbContext
    {
        public GamePostsDbContext(DbContextOptions<GamePostsDbContext> options) : base(options)
        {
            
        }

        public DbSet<GameInfoEntity> GamesInfo { get; set; }   
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CreatorEntity> Creators { get; set; }
    }
}
