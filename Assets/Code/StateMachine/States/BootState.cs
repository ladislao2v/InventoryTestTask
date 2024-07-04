using System.Linq;
using Code.Model.Inventory;
using Code.Model.Items;
using Code.Model.Units;
using Code.Services.AssetProvider;
using Code.Services.GameDataService;
using Code.Services.RandomItemService;
using Code.StateMachine.Core.Interfaces;
using Code.Views.Popups;

namespace Code.StateMachine.States
{
    public class BootState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameDataService _gameDataService;
        private readonly IInventory _inventory;
        private readonly Player _player;
        private readonly Enemy _enemy;
        private readonly GameOverPopup _gameOverPopup;

        public BootState(IStateMachine stateMachine, IAssetProvider assetProvider, 
            IGameDataService gameDataService, IInventory inventory, 
            Player player, Enemy enemy, GameOverPopup gameOverPopup)
        {
            _stateMachine = stateMachine;
            _assetProvider = assetProvider;
            _gameDataService = gameDataService;
            _inventory = inventory;
            _player = player;
            _enemy = enemy;
            _gameOverPopup = gameOverPopup;
        }

        public void Enter()
        {
            LoadData();

            var allItems = _assetProvider.GetConfigs<Item>(ResourcesPaths.ItemsPath);
            
            if(_inventory.IsEmpty)
                FillInventory(allItems);
                
            IRandomItemService randomItemService = new RandomItemService(allItems);

            _player.Died += _gameOverPopup.Show;

            var randomItem = randomItemService.GetRandomItem();
            _enemy.Died += () => _inventory.Add(randomItem, randomItem.MaxStack);
            _enemy.Died += () => _enemy.Hill(100);

            _stateMachine
                .EnterState<PlayerTurnState>();
        }

        public void Exit()
        {
            _gameDataService.SaveData();
        }

        private void LoadData()
        {
            _gameDataService.Add(_player);
            _gameDataService.Add(_enemy);

            _gameDataService.LoadData();
        }

        private void FillInventory(Item[] allItems)
        {
            var startItems = allItems.Where(x => x.IsStart);

            foreach (var item in startItems)
                _inventory.Add(item, item.MaxStack);
        }
    }
}
