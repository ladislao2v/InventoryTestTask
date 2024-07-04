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

        private float _delay = 0.78f;

        public Weapon(WeaponConfig config, IInventory inventory)
        {
            _config = config;
            _inventory = inventory;
        }
        
        public async void Shoot(Unit unit)
        {
            if(!_inventory.TryFindSlot(_config.Ammo, out ISlot slot))
                return;

            var possibleVolley = slot.Count.Value - _config.Volley;

            if (possibleVolley <= 0)
                possibleVolley = slot.Count.Value;
            else
                possibleVolley = _config.Volley;
            
            slot.RemoveCount(possibleVolley);
            
            for (int i = 0; i < possibleVolley; i++)
            {
                unit.TakeDamage(_config.Damage);
                await UniTask.WaitForSeconds(_delay);
            }
        }
    }
}