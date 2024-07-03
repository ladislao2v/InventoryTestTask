using System;
using Code.Model.Inventory;
using Code.Model.Units;
using Code.Model.Weapons;
using Code.StateMachine.Core.Interfaces;
using Code.StateMachine.States;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Views
{
    public class Shootter : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _pistolConfig;
        [SerializeField] private WeaponConfig _gunConfig;
        
        private Weapon _weapon;
        private Enemy _enemy;
        private IInventory _inventory;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(Enemy enemy, IInventory inventory, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _weapon = new Weapon(_pistolConfig, inventory);
            _enemy = enemy;
            _inventory = inventory;
        }

        public void PickPistol()
        {
            _weapon = new Weapon(_pistolConfig, _inventory);
        }

        public void PickGun()
        {
            _weapon = new Weapon(_gunConfig, _inventory);
        }

        public void Shoot()
        {
            _weapon.Shoot(_enemy);
            _stateMachine.EnterState<EnemyTurnState>();
        }
    }
}