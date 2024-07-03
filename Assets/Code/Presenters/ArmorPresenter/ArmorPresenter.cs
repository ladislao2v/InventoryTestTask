using System;
using Code.Model.Units;
using Code.Views.Armors;
using UniRx;
using UnityEngine;

namespace Code.Presenters.ArmorPresenter
{
    public class ArmorPresenter : MonoBehaviour
    {
        private readonly CompositeDisposable _disposables = new();
        
        private UnitArmor _model;
        private ArmorView _view;

        public void Construct(UnitArmor model, ArmorView view)
        {
            _model = model;
            _view = view;
            
            
            _model.Body.Subscribe(_view.SetBodyArmor).AddTo(_disposables);
            _model.Head.Subscribe(_view.SetHeadArmor).AddTo(_disposables);
        }

        private void OnDestroy() => 
            _disposables.Dispose();
    }
}