namespace PvZGame.Models.Game
{
    public class Game
    {
        public Level.Level CurrentLevel { get; }

        // Принимаем уровень в конструктор
        public Game(Level.Level level)
        {
            CurrentLevel = level;
        }

        public void Start()
        {
            // Логика старта игры с текущим уровнем
            // Например, инициализация растений и зомби на уровне
        }

        public void Update()
        {
            // Логика обновления игры, например, передвижение зомби, атаки растений
        }
    }
}