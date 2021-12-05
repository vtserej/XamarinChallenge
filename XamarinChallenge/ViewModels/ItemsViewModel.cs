using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinChallenge.Models;
using XamarinChallenge.Views;

namespace XamarinChallenge.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;
        private string _searchText;

        private ObservableCollection<Item> _items;
        private IEnumerable<Item> _itemsCache;

        public Command LoadItemsCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Element List";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                _itemsCache = await DataStore.GetItemsAsync(true);
                Items.Clear();
                foreach (var item in _itemsCache)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ObservableCollection<Item> Items
        {
            get => _items;
            set
            {
                SetProperty(ref _items, value);
            }
        }


        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                OnTextFiltered(value);
            }
        }

        private void OnTextFiltered(string text)
        {
            var searchText = text.ToLower();
            Items = new ObservableCollection<Item>(_itemsCache.Where(item => item.Text.ToLower().Contains(searchText) || item.Description.ToLower().Contains(text)));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
