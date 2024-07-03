using System;
using Code.Model.Inventory;
using UnityEngine;

namespace Code.Views.Inventory.Slots
{
    public interface ISlotView
    {
        ISlot SlotData { get; }
        bool Taken { get; }

        event Action<ISlot> Clicked;
        
        void Construct(ISlot slot);
        void Clear();
    }
}