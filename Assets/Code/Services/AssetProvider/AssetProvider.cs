using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Services.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        public async UniTask<T> GetPrefab<T>(string path) where T : MonoBehaviour
        {
            var prefab = await Resources.LoadAsync<T>(path);
            
            return (T) prefab;
        }

        public T[] GetConfigs<T>(string path) where T : ScriptableObject => 
            Resources.LoadAll<T>(path);
    }
}