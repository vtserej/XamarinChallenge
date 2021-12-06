using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XamarinChallenge.Models;
using Xamarin.Forms;
using XamarinChallenge.Services;

namespace XamarinChallenge.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string imageUrl;
        public string Id { get; set; }

        public ItemDetailViewModel()
        {
            DowloadImageCommand = new Command(async () => await DownloadImage());
        }

        public Command DowloadImageCommand { get; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ImageUrl
        {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                imageUrl = item.ImageUrl;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async Task DownloadImage()
        {
            var downloader = DependencyService.Get<IDownloader>();

            var result = await downloader.DownloadImage(ImageUrl);

            await App.Current.MainPage.DisplayAlert("Alert", result ? "Image downloaded" : "Image failed to download", "OK");
        }
    }
}
