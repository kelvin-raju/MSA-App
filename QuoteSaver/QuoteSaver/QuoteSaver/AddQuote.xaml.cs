using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuoteSaver
{
    public partial class AddQuote : ContentPage
    {
        Quote quote;
        IBingSpellCheckService check;

        public AddQuote()
        {
            InitializeComponent();
            quote = new Quote();
            check = new BingSpellCheckService();
        }

        private void quote_TextChanged(object sender, TextChangedEventArgs e)
        {
            quote.quote = e.NewTextValue;
        }

        private void author_TextChanged(object sender, TextChangedEventArgs e)
        {
            quote.author = e.NewTextValue;
        }

        private async void addQuote(object sender, EventArgs e)
        {
            await AzureManager.AzureManagerInstance.PostQuote(quote);
            await Navigation.PopAsync();
        }

        public async void SpellCheckQuote(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(quoteField.Text))
                {
                    var spellCheckRes = await check.SpellChecker(quoteField.Text);
                    foreach (var flagged in spellCheckRes.FlaggedTokens)
                    {
                        quoteField.Text = quoteField.Text.Replace(flagged.Token, flagged.suggestions.FirstOrDefault().Suggestion);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
