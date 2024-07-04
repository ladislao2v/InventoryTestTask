using System;
using System.Linq;
using Code.Model.Items;
using Code.Services.SaveLoadDataService;
using UniRx;

namespace Code.Model.Inventory
{
    public class Inventory : IInventory
    {
        private readonly ReactiveCollection<ISlot> _slots = new();

        public float Weight => _slots.Sum(slot => slot.Weight);
        public bool IsEmpty => _slots.Count == 0;
        public IReactiveCollection<ISlot> Slots => _slots;
        
        public void Add(IItem item, int count = 1)
        {
            if (count < 1)
                throw new ArgumentException(nameof(count));

            if (TryFindSlot(item, out ISlot slot))
            {
                if (item.MaxStack - slot.Count.Value > count)
                {
                    slot.AddCount(count);
                }
                else
                {
                    var newCount = slot.Count.Value;
                    slot.AddCount(item.MaxStack - slot.Count.Value);
                    _slots.Add(new Slot(item, newCount, Remove));
                }

                return;
            }
            
            _slots.Add(new Slot(item, count, Remove));
        }

        public void Remove(IItem item)
        {
            if (TryFindSlot(item, out ISlot slot) == false)
                throw new ArgumentException(nameof(item));
            
            _slots.Remove(slot);    
        }

        public bool TryFindSlot(IItem item, out ISlot slot)
        {
            slot = _slots.FirstOrDefault(x => x.Item == item);

            return slot != null;
        }
    }
}