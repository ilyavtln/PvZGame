using System.Windows;
using PvZGame.Models.Level;
using PvZGame.Services;

namespace PvZGame.Views;

public partial class GameLoadingWindow : Window
{
    private GameManager _gameManager;
    private Level _currentLevel;
    
    public GameLoadingWindow(Level level, GameManager gameManager)
    {
        _gameManager = gameManager;
        _currentLevel = level;
        InitializeComponent();
        Loaded += OnLoaded;
    }
    
    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await LoadGameResourcesAsync();
        
        var nextWindow = new GameWindow(_currentLevel, _gameManager);
        nextWindow.Show();
        
        this.Close();
    }
    
    private async Task LoadGameResourcesAsync()
    {
        await Task.Delay(300);
    }
}