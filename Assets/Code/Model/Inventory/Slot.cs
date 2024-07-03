using System;
using Code.Model.Items;
using UniRx;

namespace Code.Model.Inventory
{
    public class Slot : ISlot
    {
        private readonly ReactiveProperty<int> _count;
        private readonly Action<IItem> _onItemEnded;
        public IItem Item { get; private set; }
        public IReactiveProperty<int> Count => _count;
        public float Weight => Item.Weight * Count.Value;

        public Slot(IItem slot, int count, Action<IItem> onItemEnded)
        {
            Item = slot;
            _count = new ReactiveProperty<int>(count);
            _onItemEnded = onItemEnded;
        }
        
        public void AddCount(int count)
        {
            if (count < 1)
                throw new ArgumentException(nameof(count));

            _count.Value += count;
        }

        public void RemoveCount(int count = 1)
        {
            if (count < 1)
                throw new ArgumentException(nameof(count));

            _count.Value -= count;
            
            if(_count.Value <= 0)
                _onItemEnded.Invoke(Item);
        }
    }
}