using Code.Model.Inventory;
using Code.Model.Units;
using Cysharp.Threading.Tasks;
using TMPro;

namespace Code.Model.Weapons
{
    public class Weapon
    {
        private readonly WeaponConfig _config;
        private readonly IInventory _inventory;

        public Weapon(WeaponConfig config, IInventory inventory)
        {
            _config = config;
            _inventory = inventory;
        }
        
        public void Shoot(Unit unit)
        {
            if(!_inventory.TryFindSlot(_config.Ammo, out ISlot slot))
                return;
            
            slot.RemoveCount(_config.Volley);
            
            unit.TakeDamage(_config.Damage);
        }
    }
}