using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PvZGame.Models.Game;
using PvZGame.Models.Level;
using PvZGame.Models.Plants;
using PvZGame.Services;

namespace PvZGame.Views
{
    public partial class GameWindow : Window
    {
        private GameManager _gameManager;
        private LevelManager _levelManager;
        private Level _currentLevel;
        
        public GameWindow(Level level, GameManager gameManager)
        {
            InitializeComponent();
            _gameManager = gameManager;
            _levelManager = new LevelManager(gameManager);
            _currentLevel = level;
            LoadLevel(level);
            AddGridBorders(5, 9);
        }

        private void LoadLevel(Level level)
        {
            LevelTextBlock.Text = $"Уровень: {level.LevelNumber}";

            // Загружаем растения
            foreach (var plant in level.Plants)
            {
                // Создаем новое изображение растения
                var plantImage = new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/{plant.ImagePath}")),
                    Width = 50,
                    Height = 50
                };

                // Определяем, в какую ячейку сетки помещать растение (по позиции)
                int row = (int)(plant.PositionY / 100); // Примерное деление для строк
                int col = (int)(plant.PositionX / 100); // Примерное деление для колонок

                Panel.SetZIndex(plantImage, 100);
                
                // Добавляем изображение растения в нужную ячейку Grid
                GameGrid.Children.Add(plantImage);
                Grid.SetRow(plantImage, row);
                Grid.SetColumn(plantImage, col);
            }
        }
        
        private void LevelSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем и отображаем окно выбора уровней
            LevelSelectionWindow levelSelectionWindow = new LevelSelectionWindow(_gameManager);
            levelSelectionWindow.Show();
            this.Close();
        }
        
        private void LevelSelectionButtonComplete_Click(object sender, RoutedEventArgs e)
        {
            _gameManager.CompleteLevelById(_currentLevel.LevelNumber - 1);
        }

        private void LevelSelectionButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            _gameManager.CompleteLevelById(_currentLevel.LevelNumber - 1);
            _gameManager.NextLevel();
            var gameWindow = new GameWindow(_gameManager.GetCurrentLevel(), _gameManager);
            gameWindow.Show();
            this.Close();
        }
        
        private void AddGridBorders(int rows, int columns)
        {
            // Добавляем границы для каждой ячейки сетки
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var border = new Rectangle
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 1
                    };
                    GameGrid.Children.Add(border);
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, col);
                }
            }
        }

        private void GameGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Получаем позицию мыши относительно GameGrid
            var mousePos = e.GetPosition(GameGrid);

            // Определяем номер колонки и строки
            int col = (int)(mousePos.X / (GameGrid.ActualWidth / 9));
            int row = (int)(mousePos.Y / (GameGrid.ActualHeight / 5));

            // Проверяем, чтобы не выйти за пределы сетки
            if (col >= 0 && col < 9 && row >= 0 && row < 5)
            {
                Plant plant = new GreenPlant("1", col * 100, row * 100); 
                _currentLevel.AddPlant(plant);
                LoadLevel(_currentLevel);
            }
        }

    }
}
