using System.Windows.Media.Imaging;
using System.Windows.Controls;
using PvZGame.Models.Zombies;

namespace PvZGame.Models.Plants;

public class Plant
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public double PositionX { get; set; }
    public double PositionY { get; set; }
    public Image Image { get; set; }
    public string ImagePath { get; set; }

    public Plant(string name, int health, int damage, string imagePath)
    {
        Name = name;
        Health = health;
        Damage = damage;
        PositionX = 0;
        PositionY = 0;
        
        ImagePath = imagePath;
        
        Image = new Image
        {
            Source = new BitmapImage(new Uri(imagePath, UriKind.Relative)),
            Width = 50,
            Height = 50
        };
    }

    public void Attack(Zombie zombie)
    {
        zombie.Health -= Damage;
    }
}
