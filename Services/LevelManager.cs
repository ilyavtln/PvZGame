using PvZGame.Models.Game;
using PvZGame.Models.Level;

namespace PvZGame.Services
{
    public class LevelManager
    {
        private readonly GameManager _gameManager;

        public LevelManager(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public Game LoadLevel()
        {
            Level currentLevel = _gameManager.GetCurrentLevel();
            return _gameManager.LoadCurrentGame();
        }

        public void CompleteLevel()
        {
            _gameManager.CompleteCurrentLevel();
        }

        public void MoveToNextLevel()
        {
            if (!_gameManager.IsCurrentLevelCompleted())
            {
                throw new InvalidOperationException("Текущий уровень не завершен.");
            }

            _gameManager.NextLevel();
        }
    }
}