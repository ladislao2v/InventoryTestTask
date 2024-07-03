using Code.Model.Inventory;
using Code.Model.Units;
using Code.Services.Factories.StateFactory;
using Code.Services.ItemUser;
using Code.Views.Inventory;
using Code.Views.Popups;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.CompositionRoot
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
        [SerializeField] private GameOverPopup _gameOverPopup;

        public override void InstallBindings()
        {
            BindInventory();
            BindGraphicRaycaster();
            BindUnits();
            BindItemUser();
            BindGameOverPopup();
            BindStateFactory();
            BindStateMachine();
        }

        private void BindGameOverPopup()
        {
            Container.Bind<GameOverPopup>().FromInstance(_gameOverPopup).AsSingle();
        }

        private void BindItemUser()
        {
            Container.BindInterfacesAndSelfTo<ItemUser>().AsSingle();
        }

        private void BindUnits()
        {
            Container.Bind<Player>().AsSingle();
            Container.Bind<Enemy>().AsSingle();
        }

        private void BindGraphicRaycaster()
        {
            Container.Bind<GraphicRaycaster>().FromInstance(_graphicRaycaster).AsSingle();
        }

        private void BindInventory()
        {
            Container.BindInterfacesAndSelfTo<Inventory>().AsSingle();
            Container.BindInterfacesAndSelfTo<InventoryView>().FromInstance(_inventoryView).AsSingle();
        }
        private void BindStateMachine() => 
            Container
                .BindInterfacesAndSelfTo<StateMachine.Core.StateMachine>()
                .AsSingle();

        private void BindStateFactory() => 
            Container
                .BindInterfacesAndSelfTo<StateFactory>()
                .AsSingle();
        
    }
}