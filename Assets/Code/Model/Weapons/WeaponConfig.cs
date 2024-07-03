using Code.Model.Items;
using UnityEngine;

namespace Code.Model.Weapons
{
    [CreateAssetMenu(menuName = "Create WeaponConfig", fileName = "WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        [field:SerializeField] public int Damage { get; private set; }
        [field:SerializeField] public int Volley { get; private set; } 
        [field:SerializeField] public Item Ammo { get; set; }
    }
}