using zxcforum.core.models;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace zxcforum.core.utils
{
    public static class DefaultImages
    {
        public static Image GetAvatar(User user)
        {
            Console.WriteLine($"{user.picture} PICTURE");
            if(user.picture != "") return Image.FromFile(Path.Combine(DefaultPaths.AvatarsPath, user.picture));
            else return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "profile.png"));
        }
        public static Image GetAvatar(string name)
        {
            Console.WriteLine($"{name} PICTURE");
            if(name != "") return Image.FromFile(Path.Combine(DefaultPaths.AvatarsPath, name));
            else return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "profile.png"));
        }
        public static Image GetPoster(Film film)
        {
            if(film["poster"] != "NULL") return Image.FromFile(Path.Combine(DefaultPaths.PostersPath, film["poster"]));
            else return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "poster.jpg"));
        }
        public static Image GetDefaultImage(string name)
        {
            Console.WriteLine(DefaultPaths.DefaultImagesPath);
            return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, name));
        }
        public static Image GetMoreIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "menu-burger.png")); }
        public static Image GetHomeIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "home.png")); }
        public static Image GetTicketsIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "receipt.png")); }
        public static Image GetMoviesIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "clapper-open.png")); }
        public static Image GetUsersIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "user-gear.png")); }
        public static Image GetSessionIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "eye.png")); }
        public static Image GetGenreIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "theater-masks.png")); }
        public static Image GetHallIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, "stage-theatre.png")); }
        public static Image GetRandomBackgroundImage(string name) { return Image.FromFile(Path.Combine(DefaultPaths.DefaultImagesPath, name)); }

        public static List<Image> GetRandomBackgroundImages(int count)
        {
            List<Image> images = new List<Image>();
            string[] imagesNames = Directory.GetFiles(DefaultPaths.RandomImagesPath);
            Random random = new Random();
            for(int i = 0; i < count; i++)
            {
                
                int randomNumber = random.Next(0, imagesNames.Count());
                images.Add(GetRandomBackgroundImage(imagesNames[randomNumber]));
            }
            return images;
        }
    }
}
