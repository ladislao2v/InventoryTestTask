using System;
using Code.Model.Items;
using Code.Services.SaveLoadDataService;
using UniRx;

namespace Code.Model.Units
{
    public class UnitArmor
    {
        private ReactiveProperty<HeadArmor> _head = new();
        private ReactiveProperty<BodyArmor> _body = new();
        public int Value => 
            _body.Value ? _body.Value.ArmorValue : 0 + (_head.Value ? _head.Value.ArmorValue : 0);

        public IReadOnlyReactiveProperty<HeadArmor> Head => _head;
        public IReadOnlyReactiveProperty<BodyArmor> Body => _body;

        public void AddHamlet(HeadArmor headArmor) => _head.Value = headArmor;

        public void AddBodyArmor(BodyArmor bodyArmor) => _body.Value = bodyArmor;
        
    }
}