using System.Windows;
using PvZGame.Helpers;
using PvZGame.Services;
using PvZGame.Views;

namespace PvZGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly SettingsManager _settingsManager = new SettingsManager();
    private GameManager _gameManager = new GameManager();
    
    public MainWindow()
    {
        ApplyWindowSettings();
        InitializeComponent();
    }
    
    // Запуск
    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        var levelWindow = new LevelSelectionWindow(_gameManager); 
        levelWindow.Show();
        this.Close();
    }

    // Настройки
    private void SettingsButton_Click(object sender, RoutedEventArgs e)
    {
        // Открыть окно настроек
        var settingsWindow = new MainSettingsWindow();
        settingsWindow.ShowDialog();
        ApplyWindowSettings();
    }

    // Выход
    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
    
    private void ApplyWindowSettings()
    {
        if (_settingsManager.IsFullScreenMode)
        {
            WindowState = WindowState.Maximized;
        }
        else
        {
            WindowState = WindowState.Normal;
        }
    }

}