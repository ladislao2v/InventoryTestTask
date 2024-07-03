using System;
using System.Collections.Generic;
using Code.Model.Items;

namespace Code.Extensions
{
    public static class UseButtonNames
    {
        public static Dictionary<Type, string> Names = new()
        {
            [typeof(HeadArmor)] = "Экипировать",
            [typeof(BodyArmor)] = "Экипировать",
            [typeof(MedicineKit)] = "Лечить",
            [typeof(PistolAmmo)] = "Купить",
            [typeof(GunAmmo)] = "Купить",
        };
    }
}