using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class GameInfoEntity
    {
        public Guid id { get; set; }
        public string name { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
        public string icon { get; set; } = String.Empty;
        public DateTime? date { get; set; } = null;
        public Guid creatorID { get; set; }
        public double stat { get; set; } = 0;
        public byte[] image { get; set; } = [];
        public int downloads { get; set; } = 0;
    }
}
