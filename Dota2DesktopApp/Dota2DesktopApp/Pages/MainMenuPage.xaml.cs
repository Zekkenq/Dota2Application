using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dota2DesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            Refresh();
        }
        private async void Refresh()
        {
            string response = await MainWindow.httpClient.GetStringAsync("http://localhost:44723/api/Heroes");
            DGHero.ItemsSource = null;
            DGHero.ItemsSource = JsonConvert.DeserializeObject<List<Model.Hero>>(response);
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate()) return;
            AddEditHeroWindow addEditHeroWindow = new AddEditHeroWindow(new Model.Hero());
            addEditHeroWindow.ShowDialog();
            Refresh();
        }
        private bool Validate()
        {
            if(DGHero.SelectedItem == null)
            {
                MessageBox.Show("Select Item");
                return false;
            }
            return true;
        }
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate()) return;
            AddEditHeroWindow addEditHeroWindow = new AddEditHeroWindow((Model.Hero)DGHero.SelectedItem);
            addEditHeroWindow.ShowDialog();
            Refresh();

        }

        private async void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate()) return;
            string response = MainWindow.httpClient.DeleteAsync($"http://localhost:44723/api/Heroes/{((Model.Hero)DGHero.SelectedItem).Id}").Result.StatusCode.ToString();
            Refresh();
            
        }
    }
}
