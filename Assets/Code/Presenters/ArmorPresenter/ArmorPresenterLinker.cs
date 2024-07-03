using Code.Model.Units;
using Code.Views.Armors;
using UnityEngine;
using Zenject;

namespace Code.Presenters.ArmorPresenter
{
    [RequireComponent(typeof(ArmorPresenter))]
    [RequireComponent(typeof(ArmorView))]
    public class ArmorPresenterLinker : MonoBehaviour
    {
        [Inject]
        private void Construct(Player player)
        {
            GetComponent<ArmorPresenter>().Construct(player.Armor, GetComponent<ArmorView>());
        }
    }
}