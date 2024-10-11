using PvZGame.Models.config;
using PvZGame.Models.Game;
using PvZGame.Models.Level;

namespace PvZGame.Services
{
    public class GameManager
    {
        private readonly List<Level> _levels = [];
        private int _currentLevelIndex;

        public int LevelsCount => _levels.Count;

        public GameManager()
        {
            _currentLevelIndex = 0;
            InitializeLevels();
        }

        private void InitializeLevels()
        {
            foreach (var level in LevelsConfig.Levels)
            {
                _levels.Add(level);
            }
        }

        public Game LoadCurrentGame()
        {
            var currentLevel = GetCurrentLevel();
            var game = new Game(currentLevel);

            return game;
        }

        public Level GetLevel(int index)
        {
            if (index >= 0 && index < _levels.Count)
            {
                return _levels[index];
            }
            return null;
        }

        public Level GetCurrentLevel()
        {
            return _levels[_currentLevelIndex];
        }

        public bool IsCurrentLevelCompleted()
        {
            return _levels[_currentLevelIndex].IsCompleted;
        }

        public void CompleteCurrentLevel()
        {
            _levels[_currentLevelIndex].CompleteLevel();
        }

        public void NextLevel()
        {
            if (_currentLevelIndex < _levels.Count - 1)
            {
                _currentLevelIndex++;
            }
        }

        public void ChangeCurrentLevel(int newLevelIndex)
        {
            if (newLevelIndex < _levels.Count - 1)
            {
                _currentLevelIndex = newLevelIndex;
            }
        }

        public void ResetCurrentLevel()
        {
            _levels[_currentLevelIndex].ResetLevel();
        }

        public void CompleteLevelById(int id)
        {
            _levels[id].CompleteLevel();
        }
    }
}