using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserEntity
    {
        public Guid id { get; set; }
        public string userName { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public string phone { get; set; } = String.Empty;
        public bool isAdmin { get; set; } = false;

    }
}
