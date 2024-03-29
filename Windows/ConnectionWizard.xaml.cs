﻿using Newtonsoft.Json;
using System.IO;
using System.Windows;
using xelas_not_so_convenient_mysql_interface.JSONClasses;

namespace xelas_not_so_convenient_mysql_interface.Windows
{
    /// <summary>
    /// Interaction logic for ConnectionWizard.xaml
    /// </summary>
    public partial class ConnectionWizard : Window
    {
        public ConnectionWizard()
        {
            InitializeComponent();
        }

        private void write_button_Click(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection(db_ip.Text, db_name.Text, username.Text, username_password.Password);
            using (StreamWriter file = File.CreateText(".\\Config\\connection.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, connection);
                MessageBox.Show("wrote to file");
            }

            MessageBox.Show("Wrote to file!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}