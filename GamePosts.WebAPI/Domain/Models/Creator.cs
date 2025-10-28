using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Creator
    {
        public const int IMAGE_MAX_SIZE = 6291456;
        public Guid id { get; }
        public string name { get; } = String.Empty;
        public string description { get; } = String.Empty;
        public int gamesCount { get; } = 0;
        public DateTime? date { get; } = null;
        public string director { get; } = String.Empty;
        public byte[] companyImage { get; } = [];

        private Creator(string name, string description, int gamesCount, DateTime? date, string director, byte[] companyImage)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.description = description;
            this.gamesCount = gamesCount;
            this.date = date;
            this.director = director;
            this.companyImage = companyImage;
        }

        public static (Creator creator, string error) CreatorCreate(Guid id, string name, string description, int gamesCount, DateTime? date, string director, byte[] companyImage)
        {
            string errorString = string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(director))
            {
                errorString += "String value cannot be empty. ";
            }

            if (companyImage.Length > IMAGE_MAX_SIZE)
            {
                errorString += "Image size is too big. ";
            }

            if (gamesCount < 0)
            {
                errorString += "The value cannot be less than zero. ";
            }

            if (errorString == String.Empty)
            {
                Creator creator = new Creator(name, description, gamesCount, date, director, companyImage);

                return (creator, errorString);
            }
            else
            {
                return (null, errorString);
            }
        }
    }
}
