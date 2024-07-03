using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views.Health
{
    [RequireComponent(typeof(Slider))]
    public class HealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Slider _slider;

        public void OnHealthChanged(int health)
        {
            _slider.value = health / 100f;
        }
    }
}