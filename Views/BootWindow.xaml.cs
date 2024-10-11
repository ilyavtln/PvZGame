using System.Windows;

namespace PvZGame.Views;

/// <summary>
/// Загрузочное окно приложения
/// </summary>
public partial class BootWindow : Window
{
    public BootWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    
    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await LoadGameResourcesAsync();
        
        var mainWindow = new MainWindow();
        mainWindow.Show();
        
        this.Close();
    }
    
    private async Task LoadGameResourcesAsync()
    {
        await Task.Delay(1000);
    }
}