using System;
using Code.Model.Units;

namespace Code.Model.DamageCalculator
{
    public class ArmorDamageCalculator : IDamageCalculator
    {
        private readonly UnitArmor _armor;

        public ArmorDamageCalculator(UnitArmor armor) => _armor = armor;

        public int Calculate(int damage) => 
            damage - 2 * (int)Math.Ceiling((decimal) _armor.Value / damage);
    }
}