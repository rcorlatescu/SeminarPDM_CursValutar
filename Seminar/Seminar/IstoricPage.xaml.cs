using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using Seminar.Models;
using Seminar.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seminar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IstoricPage : ContentPage
    {
        public IstoricPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Curs> listaCurs = await SursaDate.ObtineListaCurs();

            List<ChartEntry> dateGrafic = new List<ChartEntry>();

            int i = 0;
            foreach(Curs curs in listaCurs)
            {
                dateGrafic.Add(new ChartEntry((float)curs.Valoare)
                {
                    Label = curs.Multiplicator + curs.Valuta,
                    ValueLabel = curs.Valoare.ToString(),
                    Color = new SkiaSharp.SKColor((byte)new Random().Next(0,255), (byte)new Random().Next(0, 255), (byte)new Random().Next(0, 255))
                });

                if (++i > 10)
                {
                    break;
                }
            }

            chart.Chart =new LineChart() { Entries = dateGrafic };
        }
    }
}