using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configs
{
    public class GameInfoConfig : IEntityTypeConfiguration<GameInfoEntity>
    {
        public void Configure(EntityTypeBuilder<GameInfoEntity> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.name).IsRequired();
        }
    }
}
