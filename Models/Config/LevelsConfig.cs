using PvZGame.Models.Plants;
using PvZGame.Models.Zombies;

namespace PvZGame.Models.config
{
    public abstract class LevelsConfig
    {
        public static List<Level.Level> Levels { get; } =
        [
            new Level1(),
            new Level2(),
            new Level3()
        ];

        private class Level1 : Level.Level
        {
            public Level1() : base(1)
            {
                AddPlant(new GreenPlant("Green Plant 1", 0, 0));
                AddPlant(new GreenPlant("Green Plant 2", 200, 200));
                AddPlant(new GreenPlant("Green Plant 3", 500, 500));
            }
        }
        
        private class Level2 : Level.Level
        {
            public Level2() : base(2)
            {
                AddPlant(new GreenPlant("Green Plant 1", 500, 0));
                AddPlant(new GreenPlant("Green Plant 2", 200, 200));
            }
        }
        
        private class Level3 : Level.Level
        {
            public Level3() : base(3)
            {
                AddPlant(new GreenPlant("Green Plant 1", 0, 0));
                AddPlant(new GreenPlant("Green Plant 2", 0, 150));
                AddPlant(new GreenPlant("Green Plant 2", 0, 300));
                AddPlant(new GreenPlant("Green Plant 2", 0, 450));
                AddPlant(new GreenPlant("Green Plant 2", 0, 600));
            }
        }
    }
}