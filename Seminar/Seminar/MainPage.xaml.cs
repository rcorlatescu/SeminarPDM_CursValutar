using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar.Models;
using Seminar.Services;
using Xamarin.Forms;

namespace Seminar
{
    public partial class MainPage : ContentPage
    {
        //numele paginilor sa fie succedat de Page
        //ConvertorPage
        //IstoricPage
        //DesprePage
        //SetariPage

        List<Curs> listaCurs;

        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listaCurs = await SursaDate.ObtineListaCurs();
            listViewCurs.ItemsSource = listaCurs;
        }

        private void Setari_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetariPage());
        }
    }
}
