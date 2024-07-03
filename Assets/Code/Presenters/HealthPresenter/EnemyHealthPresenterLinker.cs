using Code.Model.Units;
using Code.Views.Health;
using UnityEngine;
using Zenject;

namespace Code.Presenters.HealthPresenter
{
    [RequireComponent(typeof(HealthPresenter))]
    [RequireComponent(typeof(HealthView))]
    public class EnemyHealthPresenterLinker : MonoBehaviour
    {
        [Inject]
        private void Construct(Enemy enemy)
        {
            GetComponent<HealthPresenter>().Construct(enemy, GetComponent<IHealthView>());
        }
    }
}