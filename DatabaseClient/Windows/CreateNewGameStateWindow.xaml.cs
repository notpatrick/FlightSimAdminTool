using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DatabaseClient.Windows
{
    /// <summary>
    /// Interaction logic for CreateNewGameStateWindow.xaml
    /// </summary>
    public partial class CreateNewGameStateWindow : Window
    {
        public CreateNewGameStateWindow()
        {
            InitializeComponent();
        }

        private async void CreateGameStateButtonClick(object sender, RoutedEventArgs e)
        {
            var newGameState = new GameState
            {
                UserId = Int32.Parse(UserIDTextBox.Text),
                IsRunning = IsRunningCheckBox.IsChecked.Value,
                Score = double.Parse(ScoreTextBox.Text),
                LocationName = LocationNameTextBox.Text,
                PositionX = double.Parse(PositionXTextBox.Text),
                PositionY = double.Parse(PositionYTextBox.Text),
                SpeedX = double.Parse(SpeedXTextBox.Text),
                SpeedY = double.Parse(SpeedYTextBox.Text),
            };
            await WebConnection.CreateNewGameState(newGameState);
            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
