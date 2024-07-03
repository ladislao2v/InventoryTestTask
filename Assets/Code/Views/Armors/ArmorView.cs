using System;
using Code.Model.Items;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views.Armors
{
    public class ArmorView : MonoBehaviour
    {
        [SerializeField] private ArmorSlotView _headSlot;
        [SerializeField] private ArmorSlotView _bodySlot;

        public void SetHeadArmor(HeadArmor headArmor) => 
            _headSlot.Construct(headArmor);

        public void SetBodyArmor(BodyArmor bodyArmor) => 
            _bodySlot.Construct(bodyArmor);
    }
    
    [Serializable]
    public class ArmorSlotView
    {
        [SerializeField] private Image _logo;
        [SerializeField] private TextMeshProUGUI _valueText;
        
        public void Construct(Armor armor)
        {
            if(armor == null)
                return;

            _logo.sprite = armor.Sprite;
            _valueText.text = $"{armor.ArmorValue}";
        }
    }
}