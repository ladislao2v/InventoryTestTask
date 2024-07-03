using Code.Services.ItemUser;
using UnityEngine;

namespace Code.Model.Items
{
    public abstract class Item : ScriptableObject, IItem
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set;}
        [field: SerializeField] public float Weight { get; private set;}
        [field: SerializeField] public int MaxStack { get; private set;}
        [field: SerializeField] public bool IsStart { get; private set;}
        public abstract void Accept(IItemVisitor itemVisitor);
    }
}