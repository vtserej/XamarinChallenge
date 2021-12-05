using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinChallenge.Models;

namespace XamarinChallenge.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        private static readonly Random randomizer = new Random();

        private DateTime GetAnyDate() => DateTime.Now.AddDays(randomizer.Next(365) - 365);

        private string GetRandomImageUrl() => "https://picsum.photos/" + randomizer.Next(300);

        public MockDataStore()
        {
            GenerateRandomItems();
        }

        private void GenerateRandomItems()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing." , DateTime = GetAnyDate(), ImageUrl = GetRandomImageUrl() },

                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item",
                    Description="sed do eiusmod tempor incididunt ut labore et dolore magna." , DateTime = GetAnyDate(), ImageUrl = GetRandomImageUrl() },

                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item",
                    Description="Ut enim ad minim veniam, quis nostrud exercitation." , DateTime = GetAnyDate(), ImageUrl = GetRandomImageUrl() },

                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item",
                    Description="Duis aute irure dolor in reprehenderit." , DateTime = GetAnyDate(), ImageUrl = GetRandomImageUrl() },

                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item",
                    Description="Excepteur sint occaecat cupidatat non." , DateTime = GetAnyDate(), ImageUrl = GetRandomImageUrl() },

                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item",
                    Description="Lorem ipsum dolor sit amet." , DateTime = GetAnyDate(), ImageUrl = GetRandomImageUrl() },

                new Item { Id = Guid.NewGuid().ToString(), Text = "Seventh item",
                    Description="Sed ut perspiciatis unde omnis." , DateTime = GetAnyDate(), ImageUrl = GetRandomImageUrl() }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
