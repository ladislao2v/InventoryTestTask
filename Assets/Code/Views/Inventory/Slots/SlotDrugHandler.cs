using System.Collections.Generic;
using System.Linq;
using Code.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Code.Views.Inventory.Slots
{
    public class SlotDrugHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
    {
        private GraphicRaycaster _raycaster;
        
        private Vector3 _lastPosition;
        private Vector3 _offset;
        private float _depth;

        [Inject]
        private void Construct(GraphicRaycaster raycaster)
        {
            _raycaster = raycaster;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            _raycaster.Raycast(pointerData, results);

            var slotView = results
                .FirstOrDefault(x => x.gameObject.TryGetComponent(out SlotView slotView))
                .gameObject;
            
            if(slotView != null)
                transform.Replace(slotView.transform, _lastPosition);
            else
                transform.position = _lastPosition;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _lastPosition = transform.position;

            _depth = Camera.main.WorldToScreenPoint(transform.position).z;
            _offset = transform.position - Input.mousePosition.GetMouseWorldPosition(_depth);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 current = Input.mousePosition.GetMouseWorldPosition(_depth) + _offset;
            transform.position = new Vector3(current.x, current.y,transform.position.z);
        }
    }
}