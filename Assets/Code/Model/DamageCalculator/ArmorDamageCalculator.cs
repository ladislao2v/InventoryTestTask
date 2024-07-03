using System;
using Code.Model.Units;

namespace Code.Model.DamageCalculator
{
    public class ArmorDamageCalculator : IDamageCalculator
    {
        private readonly UnitArmor _armor;

        public ArmorDamageCalculator(UnitArmor armor) => _armor = armor;

        public int Calculate(int damage) => 
            (int)Math.Ceiling((decimal)damage - _armor.Value / damage);
    }
}