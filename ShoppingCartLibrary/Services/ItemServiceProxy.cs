using Newtonsoft.Json;
using ShoppingCartLibrary.DTO;
using ShoppingCartLibrary.Models;
using ShoppingCartLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoppingCartLibrary.Services
{
    public class ItemServiceProxy
    {
        private ItemServiceProxy()
        {
            var response = new WebRequestHandler().Get("/Inventory").Result;

            items = JsonConvert.DeserializeObject<List<Item>>(response);
        }

        private static ItemServiceProxy? instance;
        private static object instanceLock = new object();

        public static ItemServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ItemServiceProxy();
                    }

                    return instance;
                }
            }
        }

        private List<Item>? items;

        public ReadOnlyCollection<Item>? Items
        {
            get
            {
                return items?.AsReadOnly();
            }
        }

        public int LastId
        {
            get
            {
                if (items?.Any() ?? false)
                {
                    return items?.Select(c => c.Id)?.Max() ?? 0;
                }
                return 0;
            }
        }
        public async Task<IEnumerable<Item>> Get()
        {
            var result = new WebRequestHandler().Get("/Inventory").Result;
            var deserializedResult = JsonConvert.DeserializeObject<List<Item>>(result);
            items = deserializedResult.ToList() ?? new List<Item>();
            return items;
        }

        public async Task<Item> AddOrUpdate(Item? item)
        {
            var result = await new WebRequestHandler().Post("/Inventory", item);
            return JsonConvert.DeserializeObject<Item>(result);
        }

        public async Task<Item> Delete(int id)
        {
            var result = await new WebRequestHandler().Delete($"/{id}");
            var itemToDelete = JsonConvert.DeserializeObject<Item>(result);
            return itemToDelete;
        }

        public async Task<IEnumerable<Item>> Search(Query query)
        {
            if(query == null || string.IsNullOrEmpty(query.QueryString))
            {
                return await Get();
            }
            var result = await new WebRequestHandler().Post("/Inventory/Search",query);
            var deserializedResult = JsonConvert.DeserializeObject<List<Item>>(result);
            return deserializedResult;

        }
    }
}
