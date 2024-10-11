using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Configuration;
using PvZGame.Helpers;

namespace PvZGame.Views
{
    public partial class MainSettingsWindow : Window, INotifyPropertyChanged
    {
        private readonly SettingsManager _settingsManager;

        public bool IsFullScreenMode
        {
            get => _settingsManager.IsFullScreenMode;
            set
            {
                _settingsManager.IsFullScreenMode = value;
                OnPropertyChanged();
            }
        }

        public bool IsMusicEnabled
        {
            get => _settingsManager.IsMusicEnabled;
            set
            {
                _settingsManager.IsMusicEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsSoundEnabled
        {
            get => _settingsManager.IsSoundEnabled;
            set
            {
                _settingsManager.IsSoundEnabled = value;
                OnPropertyChanged();
            }
        }

        public MainSettingsWindow()
        {
            InitializeComponent();
            _settingsManager = new SettingsManager();
            LoadSettings();
            DataContext = this;
        }

        private void LoadSettings()
        {
            IsFullScreenMode = _settingsManager.IsFullScreenMode;
            IsMusicEnabled = _settingsManager.IsMusicEnabled;
            IsSoundEnabled = _settingsManager.IsSoundEnabled;
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Настройки сохранены.");
            this.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
