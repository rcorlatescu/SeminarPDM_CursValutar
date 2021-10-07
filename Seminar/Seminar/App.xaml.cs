using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seminar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();//pagina incarcata cand rulam aplicatia
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
