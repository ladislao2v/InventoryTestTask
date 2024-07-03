using System;
using System.Collections.Generic;
using System.Linq;
using Code.Model.Inventory;
using Code.Model.Items;
using Code.Presenters.Inventory;
using Code.Views.Inventory.Slots;
using Code.Views.Popups;
using UnityEngine;

namespace Code.Views.Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private List<SlotView> _slotViews;
        [SerializeField] private InventorySlotPopup _popup;

        public event Action<IItem> DeleteClicked; 

        private void OnEnable()
        {
            foreach (var slotView in _slotViews)
                slotView.Clicked += ShowSlotPopup;
        }

        private void OnDisable()
        {
            foreach (var slotView in _slotViews)
                slotView.Clicked -= ShowSlotPopup;
        }

        public void Add(ISlot slot)
        {
            var slotView = _slotViews
                .FirstOrDefault(x => x.Taken == false);
            
            slotView?.Construct(slot);
        }

        public void Remove(ISlot slot)
        {
            var slotView = _slotViews
                .FirstOrDefault(x => x.SlotData == slot);
            
            slotView?.Clear();
        }

        private void ShowSlotPopup(ISlot slot)
        {
            if (slot == null)
                return;
            
            _popup.Construct(slot);
            _popup.DeleteButton.onClick
                .AddListener(() => DeleteClicked?.Invoke(slot.Item));
            _popup.Show();
        }
    }
}