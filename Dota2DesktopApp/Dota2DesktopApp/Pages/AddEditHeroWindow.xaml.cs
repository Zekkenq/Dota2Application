using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// Провели код ревью: Шарафеев Искандер и Шагиахметова Зиля

namespace Dota2DesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AddEditHeroWindow.xaml
    /// </summary>
    public partial class AddEditHeroWindow : Window
    {
        Model.Hero postHero;
        public AddEditHeroWindow(Model.Hero hero)
        {
            InitializeComponent();
            postHero = hero;
            this.DataContext = postHero;
        }

        private async void BChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog().GetValueOrDefault())
            {
                postHero.Avatar = File.ReadAllBytes(openFileDialog.FileName);
                IAvatar.Source = Tools.BytesToImage(File.ReadAllBytes(openFileDialog.FileName));
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if(postHero.Id == 0)
            {
                HttpContent AddhttpContent = new StringContent(JsonConvert.SerializeObject(postHero), Encoding.UTF8, "application/json");
                string response = MainWindow.httpClient.PostAsync($"http://localhost:44723/api/Heroes", AddhttpContent).Result.StatusCode.ToString();
                this.Close();
            }
            else
            {
                HttpContent EdithttpContent = new StringContent(JsonConvert.SerializeObject(postHero), Encoding.UTF8, "application/json");
                string response = MainWindow.httpClient.PutAsync($"http://localhost:44723/api/Heroes/{postHero.Id}", EdithttpContent).Result.StatusCode.ToString();
                this.Close();
            }
            // Переменные названы верно, ошибок нет
        }
    }
}
