using System.Collections.Generic;
using PvZGame.Models.Plants;
using PvZGame.Models.Zombies;

namespace PvZGame.Models.Level
{
    public class Level
    {
        public int LevelNumber { get; }
        public string ImagePath { get; }
        public List<Zombie> Zombies { get; }
        public List<Plant> Plants { get; }
        public bool IsCompleted { get; private set; }
        
        public Level(int levelNumber)
        {
            LevelNumber = levelNumber;
            ImagePath = "";
            Zombies = new List<Zombie>();
            Plants = new List<Plant>();
            IsCompleted = false;
        }

        public void AddZombie(Zombie zombie)
        {
            Zombies.Add(zombie);
        }

        public void AddPlant(Plant plant)
        {
            Plants.Add(plant);
        }

        public void CompleteLevel()
        {
            IsCompleted = true;
        }

        public void ResetLevel()
        {
            IsCompleted = false;
            Zombies.Clear();
            Plants.Clear();
        }
    }
}