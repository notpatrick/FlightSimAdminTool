﻿using System;
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
    /// Interaction logic for CreateNewUserWindow.xaml
    /// </summary>
    public partial class CreateNewUserWindow : Window
    {
        public CreateNewUserWindow()
        {
            InitializeComponent();
        }

        private async void CreateUserButtonClick(object sender, RoutedEventArgs e)
        {
            var newUser = new User(-1, NameTextBox.Text, PasswordTextBox.Text);
            await WebConnection.CreateNewUser(newUser);
            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
