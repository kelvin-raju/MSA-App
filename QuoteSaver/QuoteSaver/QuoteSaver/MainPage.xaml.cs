using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuoteSaver
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Quote> quoteColl = new ObservableCollection<Quote>();
        public MainPage()
        {
            InitializeComponent();
            newPage.Clicked += newPage_Clicked;
            getQuotesFromDB();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            getQuotesFromDB();
        }

        public async void getQuotesFromDB()
        {
            quoteColl = await AzureManager.AzureManagerInstance.getQuotes();
            QuoteList.ItemsSource = quoteColl;
        }

        public async void newPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }
    }
}
