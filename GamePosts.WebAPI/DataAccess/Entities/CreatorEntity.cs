using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CreatorEntity
    {
        public Guid id { get; set; }
        public string name { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
        public int gamesCount { get; set; } = 0;
        public DateTime? date { get; set; } = null;
        public string director { get; set; } = String.Empty;
        public byte[] companyImage { get; set; } = [];
    }
}
