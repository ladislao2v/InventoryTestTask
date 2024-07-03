using Code.Model.Units;
using Code.Views.Health;
using UnityEngine;
using Zenject;

namespace Code.Presenters.HealthPresenter
{
    [RequireComponent(typeof(HealthPresenter))]
    [RequireComponent(typeof(HealthView))]
    public class PlayerHealthPresenterLinker : MonoBehaviour
    {
        [Inject]
        private void Construct(Player player)
        {
            GetComponent<HealthPresenter>().Construct(player, GetComponent<IHealthView>());
        }
    }
}