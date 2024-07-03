using System;
using Code.Model.Inventory;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Views.Inventory.Slots
{
    [RequireComponent(typeof(SlotDrugHandler))]
    public class SlotView : MonoBehaviour, ISlotView, IPointerClickHandler
    {
        private readonly CompositeDisposable _disposables = new ();
        
        [SerializeField] private Image _logo;
        [SerializeField] private TextMeshProUGUI _countText;

        public ISlot SlotData { get; private set; }

        public bool Taken => SlotData != null;

        public event Action<ISlot> Clicked;

        public void Construct(ISlot slot)
        {
            _logo.sprite = slot.Item.Sprite;
            _logo.enabled = true;
            _countText.text = $"{slot.Count}";
            SlotData = slot;
            
            if(slot.Count.Value > 1)
                _countText.gameObject.SetActive(true);

            SlotData.Count
                .Subscribe(OnCountChanged)
                .AddTo(_disposables);
        }

        private void OnDisable() => 
            _disposables.Dispose();

        public void Clear()
        {
            SlotData = null;
            _disposables.Dispose();
            _logo.sprite = null;
            _logo.enabled = false;
            _countText.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData) =>
            Clicked?.Invoke(SlotData);

        private void OnCountChanged(int count)
        {
            _countText.text = $"{count}";

            if (count > 1)
                _countText.gameObject.SetActive(true);    
        }
    }
}