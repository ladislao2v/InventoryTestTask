using Code.Model.DamageCalculator;
using Code.Services.SaveLoadDataService;

namespace Code.Model.Units
{
    public class Player : Unit, ILoadable, ISavable
    {
        private readonly UnitArmor _armor = new();
        private readonly ArmorDamageCalculator _armorDamageCalculator;

        public Player()
        {
            _armorDamageCalculator = new ArmorDamageCalculator(_armor);
        }

        public UnitArmor Armor => _armor;
        
        protected override int GetDealtDamage(int damage) => 
            _armorDamageCalculator
                .Calculate(damage);
        
        public void LoadData(ISaveLoadDataService saveLoadDataService)
        { 
            LoadHealth(saveLoadDataService
                .LoadByCustomKey<int?>(nameof(Player))
                .GetValueOrDefault());
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey((int?) Health.Value, nameof(Player));
        }
    }
}