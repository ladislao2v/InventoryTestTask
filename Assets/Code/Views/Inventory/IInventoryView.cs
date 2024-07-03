using System;
using Code.Model.Inventory;
using Code.Model.Items;

namespace Code.Views.Inventory
{
    public interface IInventoryView
    {
        event Action<IItem> DeleteClicked; 
        void Add(ISlot slot);
        void Remove(ISlot slot);
    }
}