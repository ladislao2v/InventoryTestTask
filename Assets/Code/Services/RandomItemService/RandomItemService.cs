using Code.Model.Items;
using UnityEngine;

namespace Code.Services.RandomItemService
{
    public class RandomItemService : IRandomItemService
    {
        private readonly Item[] _items;

        public RandomItemService(Item[] items)
        {
            _items = items;
        }
        
        public IItem GetRandomItem()
        {
            return _items[Random.Range(0, _items.Length)];
        }
    }
}