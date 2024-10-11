using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PvZGame.Models.Zombies
{
    public class Zombie
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public Image Image { get; set; }

        public Zombie(string name, int health, double positionX, double positionY, string imagePath)
        {
            Name = name;
            Health = health;
            PositionX = positionX;
            PositionY = positionY;

            // Загрузка изображения
            Image = new Image
            {
                Source = new BitmapImage(new Uri(imagePath, UriKind.Relative)),
                Width = 50,
                Height = 50
            };
        }

        public void Move()
        {
            PositionX -= 1;
        }
    }
}