using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinChallenge.Models;

namespace XamarinChallenge.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        private static readonly Random randomizer = new Random();

        private DateTime GetAnyDate() => DateTime.Now.AddDays(randomizer.Next(365) - 365);

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." , DateTime = GetAnyDate()},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." , DateTime = GetAnyDate()},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." , DateTime = GetAnyDate()},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." , DateTime = GetAnyDate()},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." , DateTime = GetAnyDate()},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." , DateTime = GetAnyDate()}
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
