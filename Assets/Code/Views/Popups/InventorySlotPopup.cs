using Code.Extensions;
using Code.Model.Inventory;
using Code.Model.Items;
using Code.Services.ItemUser;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Views.Popups
{
    public class InventorySlotPopup : Popup
    {
        [Header("Main")]
        [SerializeField] private Image _logo;
        [SerializeField] private TextMeshProUGUI _nameText;

        [Header("Weight")]
        [SerializeField] private TextMeshProUGUI _weightText;
        
        [Header("Type")]
        [SerializeField] private Image _type;
        [SerializeField] private TextMeshProUGUI _typeText;
        [SerializeField] private Sprite _armorSprite;
        [SerializeField] private Sprite _hillSprite;
        
        [Header("Buttons")]
        [SerializeField] private Button _useButton;
        [SerializeField] private TextMeshProUGUI _useButtonText;
        [SerializeField] private Button _deleteButton;

        private IItemUser _itemUser;

        public Button DeleteButton => _deleteButton;

        [Inject]
        private void Construct(IItemUser itemUser)
        {
            _itemUser = itemUser;
        }
        
        public void Construct(ISlot slot)
        {
            _type.enabled = true;
            _typeText.enabled = true;
            _logo.sprite = slot.Item.Sprite;
            _nameText.text = slot.Item.Name;
            _weightText.text = $"+{slot.Weight}";
            _useButtonText.text = UseButtonNames.Names[slot.Item.GetType()];
            
            if (slot.Item is Armor armor)
            {
                _type.sprite = _armorSprite;
                _typeText.text = $"+{armor.ArmorValue}";
            }
            
            if (slot.Item is MedicineKit kit)
            {
                _type.sprite = _hillSprite;
                _typeText.text = $"+{kit.Hill}";
            }

            if (slot.Item is Ammo)
            {
                _type.enabled = false;
                _typeText.enabled = false;
            }
            
            _useButton.onClick.AddListener(() => _itemUser.Use(slot.Item));
        }

        private void OnDisable()
        {
            _useButton.onClick.RemoveAllListeners();
            _deleteButton.onClick.RemoveAllListeners();
        }
    }
}