using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechRent.Shared.FeatureContracts;
using TechRent.Shared.Queries;

namespace TechRent.Entities
{
    public class ItemProxy
    {
        private readonly IFetchAllItems _fetchItems;
        private readonly ICreateCommand _createCommand;
        private readonly IUpdateCommand _updateCommand;
        private readonly IDeleteCommand _deleteCommand;

        private readonly List<Item> _items;
        public IReadOnlyList<Item> Items => _items;

        public event Action? ItemsLoaded;
        public event Action<Item>? ItemAdded;
        public event Action<Item>? ItemUpdated;
        public event Action<Guid>? ItemDeleted;

        public ItemProxy(IFetchAllItems fetchItems,
            ICreateCommand createCommand,
            IUpdateCommand updateCommand,
            IDeleteCommand deleteCommand)
        {
            _fetchItems = fetchItems;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;

            _items = new List<Item>();
        }

        public Item? GetItem(Guid id) => (_items.FirstOrDefault(y => y.Id == id) is Item item) ? item : null;

        public async Task Load()
        {
            IEnumerable<Item> items = await _fetchItems.Execute();

            _items.Clear();
            _items.AddRange(items);

            Guard.Against.Null(ItemsLoaded)?.Invoke();
        }

        public async Task Add(Item item)
        {
            Guard.Against.Null(item, nameof(item));

            await _createCommand.Execute(item);

            _items.Add(item);

            ItemAdded?.Invoke(item);
        }

        public async Task Update(Item item)
        {
            Guard.Against.Null(item, nameof(item));

            var currentIndex = _items.FindIndex(y => y.Id == item.Id);

            if (currentIndex != -1)
            {
                await _updateCommand.Execute(item);
                _items[currentIndex] = item;
            }
            else
            {
                _items.Add(item);
            }

            ItemUpdated?.Invoke(item);
        }

        public async Task Delete(Guid id)
        {
            await _deleteCommand.Execute(id);

            _items.RemoveAll(y => y.Id == id);

            ItemDeleted?.Invoke(id);
        }

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}
