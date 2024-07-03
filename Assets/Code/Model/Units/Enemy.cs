﻿using Code.Services.SaveLoadDataService;
using UnityEngine;

namespace Code.Model.Units
{
    public class Enemy : Unit, ILoadable, ISavable
    {
        public int Damage => 7;
        protected override int GetDealtDamage(int damage) => damage;

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            var health = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(Enemy))
                .GetValueOrDefault();
            LoadHealth(health);
        }


        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey((int?) Health.Value, nameof(Enemy));
        }
    }
}