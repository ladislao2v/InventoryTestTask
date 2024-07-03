using Code.Services.GameDataService;
using Code.Services.SceneLoader;
using Zenject;

namespace Code.Views.Popups
{
    public class GameOverPopup : Popup
    {
        private IGameDataService _gameDataService;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader, IGameDataService gameDataService)
        {
            _gameDataService = gameDataService;
            _sceneLoader = sceneLoader;
        }

        public void Restart()
        {
            _gameDataService.ClearData();
            _sceneLoader.RestartScene();
        }
    }
}