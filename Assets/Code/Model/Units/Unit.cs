using System;
using UniRx;

namespace Code.Model.Units
{
    public abstract class Unit
    {
        private readonly ReactiveProperty<int> _health = new(100);
        
        public IReadOnlyReactiveProperty<int> Health => _health;

        public event Action Died;
        
        public void TakeDamage(int damage)
        {
            _health.Value -= GetDealtDamage(damage);
            
            if(_health.Value <= 0)
                Died?.Invoke();
        }

        public void Hill(int points)
        {
            if (points < 0)
                throw new ArgumentException(nameof(points));
            
            _health.Value += points;
        }

        protected void LoadHealth(int value)
        {
            if (value == 0)
                value = 100;

            
            _health.Value = value;
        }

        protected abstract int GetDealtDamage(int damage);
    }
}