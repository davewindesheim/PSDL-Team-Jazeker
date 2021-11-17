using Appttt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appttt.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "JVE-65", Description="Product JVE-65 – Team Friesland This is your products main body of content. Here you should describe your product in detail." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "JVE-60-Windesheim", Description="Dit is een kopie van ‘Jonge parels’ maar dan special voor de ICT studenten van Windesheim Almere t.b.v. van hun ICT project." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "JVE-63", Description="Product short description for JVE-63" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "JVE-62", Description="Het midden van Flevoland verrast je door de enorme ruimte die je ervaart, in het voorjaar vol tulpen, de nieuwe Markerwadden middenin in het IJsselmeer." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "JVE-61", Description="JVE-61 Jonge Parels is een virtuele route rondom Almere en deze nieuwe stad heeft veel verrassende plekjes. Het is meer dan steen alleen." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
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