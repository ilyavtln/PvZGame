using System.Windows;
using PvZGame.Views;

namespace PvZGame;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        // Запускаем загрузку
        var bootWindow = new BootWindow();
        bootWindow.Show();
    }
}