using Code.Model.Inventory;
using Code.Views.Inventory;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Presenters.Inventory
{
    public class InventoryPresenter : MonoBehaviour
    {
        private IInventory _model;
        private IInventoryView _view;
        private CompositeDisposable _disposables;
        
        [Inject]
        public void Construct(IInventory model, IInventoryView view)
        {
            _model = model;
            _view = view;
            _disposables = new CompositeDisposable();
        }

        public void OnEnable()
        {
            _model.Slots.ObserveAdd().Subscribe(slot =>
            {
                _view.Add(slot.Value);
            }).AddTo(_disposables);

            _model.Slots.ObserveRemove().Subscribe(slot =>
            {
                _view.Remove(slot.Value);
            }).AddTo(_disposables);

            _view.DeleteClicked += _model.Remove;
        }

        public void OnDisable()
        {
            _disposables.Dispose();
            _view.DeleteClicked -= _model.Remove;
        }
    }
}