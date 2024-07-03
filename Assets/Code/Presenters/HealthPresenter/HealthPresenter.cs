using System;
using Code.Views.Health;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Unit = Code.Model.Units.Unit;

namespace Code.Presenters.HealthPresenter
{
    public class HealthPresenter : MonoBehaviour
    {
        private readonly CompositeDisposable _disposables = new();

        private Unit _model;
        private IHealthView _view;

        public void Construct(Unit model, IHealthView view)
        {
            _model = model;
            _view = view;

            _model.Health
                .Subscribe(_view.OnHealthChanged)
                .AddTo(_disposables);
            
            _view.OnHealthChanged(_model.Health.Value);
        }

        private void OnDestroy() => 
            _disposables.Dispose();
    }
}