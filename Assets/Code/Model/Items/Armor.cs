using UnityEngine;

namespace Code.Model.Items
{
    public abstract class Armor : Item
    {
        [field:SerializeField] public int ArmorValue { get; private set;}
    }
}