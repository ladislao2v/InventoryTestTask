using Code.Services.AssetProvider;
using Code.Services.Factories.StateFactory;
using Code.Services.GameDataService;
using Code.Services.SaveLoadDataService;
using Code.Services.SceneLoader;
using Zenject;

namespace Code.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAssetProvider();
            BindSceneLoader();
            BindSavingServices();
        }

        private void BindSavingServices()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameDataService>().AsSingle();
        }

        private void BindAssetProvider() => 
            Container
                .BindInterfacesAndSelfTo<AssetProvider>()
                .AsSingle();

        private void BindSceneLoader() => 
            Container
                .BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle();

        
    }
}