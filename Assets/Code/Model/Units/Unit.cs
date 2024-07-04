using System;
using UniRx;

namespace Code.Model.Units
{
    public abstract class Unit
    {
        private readonly ReactiveProperty<int> _health = new(100);
        
        private int _maxHealth = 100;

        public IReadOnlyReactiveProperty<int> Health => _health;

        public event Action Died;
        
        public void TakeDamage(int damage)
        {
            if(_health.Value <= 0)
                return;

            _health.Value -= GetDealtDamage(damage);
            
            if(_health.Value <= 0)
                Died?.Invoke();
        }

        public void Hill(int points)
        {
            if (points < 0)
                throw new ArgumentException(nameof(points));
            
            _health.Value += points;

            Math.Clamp(_health.Value, 0, _maxHealth);
        }

        protected void LoadHealth(int value)
        {
            if (value == 0)
                value = _maxHealth;
            
            _health.Value = value;
        }

        protected abstract int GetDealtDamage(int damage);
    }
}