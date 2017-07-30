using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace QuoteSaver
{
    public class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Quote> quote;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://msaquotes.azurewebsites.net");
            this.quote = this.client.GetTable<Quote>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<ObservableCollection<Quote>> getQuotes()
        {
            return await this.quote.ToCollectionAsync();
        }

        public async Task PostQuote(Quote item)
        {
            await this.quote.InsertAsync(item);
        }
    }
}
