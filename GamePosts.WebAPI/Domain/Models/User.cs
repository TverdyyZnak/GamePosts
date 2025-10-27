using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public Guid id { get; }
        public string userName { get; } = String.Empty;
        public string password { get; } = String.Empty;
        public string email { get; } = String.Empty;
        public string phone { get; } = String.Empty;
        public bool isAdmin { get; } = false;

        private User(string userName, string password, string email, string phone, bool isAdmin)
        {
            this.id = Guid.NewGuid();
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.isAdmin = isAdmin;
        }

        public (User user, string error) UserCreate(string userName, string password, string email, string phone, bool isAdmin)
        {
            string errorString = String.Empty;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                errorString += "String value cannot be empty. ";
            }

            if (errorString == String.Empty)
            {
                User user = new User(userName, password, email, phone, isAdmin);
                return (user, errorString);
            }
            else
            {
                return (null, errorString);
            }
        }
    }
}
