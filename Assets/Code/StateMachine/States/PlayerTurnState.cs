using Code.Services.Factories.StateFactory;
using Code.Services.GameDataService;
using Code.Services.SceneLoader;
using Code.StateMachine.Core.Interfaces;
using UnityEngine;

namespace Code.StateMachine.States
{
    public class PlayerTurnState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;

        public PlayerTurnState(IStateMachine stateMachine, IGameDataService gameDataService)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
        }
        
        public void Enter() { }

        public void Exit()
        {
            _gameDataService.SaveData();
        }
    }
}