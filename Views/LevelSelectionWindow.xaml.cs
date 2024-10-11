using System.Windows;
using System.Windows.Controls;
using PvZGame.Models.Level;
using PvZGame.Services;

namespace PvZGame.Views
{
    public partial class LevelSelectionWindow : Window
    {
        private GameManager _gameManager;

        public LevelSelectionWindow(GameManager gameManager)
        {
            _gameManager = gameManager;
            InitializeComponent();
            LoadLevels();
        }

        private void LoadLevels()
        {
            LevelListBox.Items.Clear();

            // Добавляем уровни в ListBox с их состоянием
            for (int i = 0; i < _gameManager.LevelsCount; i++)
            {
                var level = _gameManager.GetLevel(i);
                var levelName = $"Уровень {level.LevelNumber} - {(level.IsCompleted ? "Пройден" : "Не пройден")}";
                LevelListBox.Items.Add(new ListBoxItem { Content = levelName, Tag = level });
            }
        }

        private void LevelListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LevelListBox.SelectedItem is ListBoxItem selectedItem && selectedItem.Tag is Level selectedLevel)
            {
                int selectedLevelIndex = selectedLevel.LevelNumber - 1;

                // Проверка, если текущий уровень пройден или предыдущий уровень пройден
                if (selectedLevel.IsCompleted || (selectedLevelIndex == 0 || _gameManager.GetLevel(selectedLevelIndex - 1).IsCompleted))
                {
                    // Переходим к выбранному уровню
                    var gameWindow = new GameLoadingWindow(selectedLevel, _gameManager);
                    gameWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Сначала пройдите предыдущий уровень.");
                }
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
             mainWindow.Show();
            this.Close();
        }
    }
}
