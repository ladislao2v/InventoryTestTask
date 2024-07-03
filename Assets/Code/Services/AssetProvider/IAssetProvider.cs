using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Services.AssetProvider
{
    public interface IAssetProvider
    {
        UniTask<T> GetPrefab<T>(string path) where T : MonoBehaviour;
        T[] GetConfigs<T>(string path) where T : ScriptableObject;
    }
}