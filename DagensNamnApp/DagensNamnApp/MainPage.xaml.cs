using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace DagensNamnApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var names = await GetNamnsdag();
            int max;
            var maxSuccess = int.TryParse(Antal.Text, out max);
            if (maxSuccess)
            {
                Namnsdagar.ItemsSource = names.Take(max);
            }
            else
            {
                await DisplayAlert("Fel input", "Får bara innehålla siffror", "OK");
            }
        }

        public static async Task<List<string>> GetNamnsdag()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var today = DateTime.Now;
            var apiData = await client.GetStringAsync($"http://api.dryg.net/dagar/v2.1/{today.Year}/{today.Month}/{today.Day}/");
            var data = JsonConvert.DeserializeObject<Rootobject>(apiData);

            var namnsdagar = new List<string>();

            foreach (var result in data.dagar[0].namnsdag)
            {
                namnsdagar.Add(result);
            }

            return namnsdagar;


        }

        public class Namnsdag
        {
            public string namnsdag { get; set; }
        }

    }
}
