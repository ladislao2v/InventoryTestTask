using System;
using Code.Model.Items;
using Code.Services.AssetProvider;
using Random = UnityEngine.Random;

namespace Code.Services.RandomItemService
{
    public interface IRandomItemService
    {
        IItem GetRandomItem();
    }

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