using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GameInfo
    {

        public const int IMAGE_MAX_SIZE = 6291456;

        public Guid id { get; }
        public string name { get; } = String.Empty;
        public string description { get; } = String.Empty;
        public string icon { get; } = String.Empty;
        public DateTime? date { get; } = null;
        public Guid creatorID { get; }
        public double stat { get; } = 0;
        public byte[] image { get; } = [];
        public int downloads { get; } = 0;

        private GameInfo(Guid id, string name, string description, DateTime? date, Guid creator, double stat, byte[] image, int downloads)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.date = date;
            this.creatorID = creator;
            this.stat = stat;
            this.image = image;
            this.downloads = downloads;
        }

        public static (GameInfo gameInfo, string error) GameInfoCreate(Guid id, string name, string description, DateTime? date, Guid creatorID, double stat, byte[] image, int downloads)
        {
            string errorString = string.Empty;

            if (downloads < 0)
            {
                errorString += "The value cannot be less than zero. ";
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                errorString += "The string value cannot be empty. ";
            }

            if (image.Length > IMAGE_MAX_SIZE)
            {
                errorString += "Image size is too big. ";
            }

            if (errorString != string.Empty)
            {
                return (null, errorString);
            }
            else
            {
                GameInfo gameInfo = new GameInfo(id, name, description, date, creatorID, stat, image, downloads);
                return (gameInfo, errorString);
            }
        }

    }
}
