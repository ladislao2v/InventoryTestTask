using Code.Model.Units;
using Code.Services.GameDataService;
using Code.StateMachine.Core.Interfaces;
using UnityEngine;

namespace Code.StateMachine.States
{
    public class EnemyTurnState : IState
    {
        private readonly Player _player;
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;
        private readonly Enemy _enemy;

        public EnemyTurnState(Player player, Enemy enemy, 
            IStateMachine stateMachine, IGameDataService gameDataService)
        {
            _player = player;
            _enemy = enemy;
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
        }
        
        public void Enter()
        {
            _player.TakeDamage(_enemy.Damage);
            _stateMachine.EnterState<PlayerTurnState>();
        }

        public void Exit()
        {
            _gameDataService.SaveData();
        }
    }
}