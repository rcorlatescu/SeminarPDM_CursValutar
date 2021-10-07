using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar.Models;
using Seminar.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seminar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertorPage : ContentPage
    {
        Dictionary<string, Curs> dictCurs = new Dictionary<string, Curs>();

        public ConvertorPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Curs> listCurs = await SursaDate.ObtineListaCurs();
            List<string> valute = new List<string>();

            listCurs.Add(new Curs() { Valuta = "RON", Valoare = 1 });


            foreach (Curs curs in listCurs)
            {
                dictCurs[curs.Valuta] = curs;
                valute.Add(curs.Valuta);
            }

            pickerValutaDest.ItemsSource = valute;
            pickerValutaSursa.ItemsSource = valute;
            pickerValutaDest.SelectedItem = "RON";
            pickerValutaSursa.SelectedItem = "EUR";
        }
        private void ConvertesteButton_Clicked(object sender, EventArgs e)
        {
            //entrySuma -> valoarea de convertit
            //pickerValutaSursa -> selectare valuta sursa
            //pickerValutaDest -> selectare valuta destinatie/ conversie

            //labelRezultat -> valoarea Rez

            //1. Preluare valoare de convertit (entrySuma.Text)
            double suma = 0;
            double.TryParse(entrySuma.Text, out suma);
            //2.Preluare valuta sursa (pickerValutaSursa.SelectedItem)
            string valutaSursa = pickerValutaSursa.SelectedItem.ToString();
            //2.1 Obtinere curs asociat (obiect Curs valuta sursa)
            Curs cursSursa = dictCurs[valutaSursa];
            //3. Preluare valuta dest (pickerValutaDest.SelectedItem)
            string valutaDest = pickerValutaDest.SelectedItem.ToString();
            //3.1 Obtinere curs asociat (obiect Curs valuta dest)
            Curs cursDest = dictCurs[valutaDest];
            //4. Calculam rezultatul
            double rezultat = suma * cursDest.Multiplicator * cursSursa.Valoare / (cursSursa.Multiplicator * cursDest.Valoare);
            //rezultat = suma x cursSursa.Multiplicator x cursSursa.Valoare / cursDest.multiplicator x cursDest.Valoare
            //5. Afisare rezultat (labelRezultat.Text)
            labelRezultat.Text = rezultat.ToString();

        }
    }
}