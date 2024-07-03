using Code.Model.Inventory;
using Code.Services.ItemUser;
using UnityEngine;

namespace Code.Model.Items
{
    public interface IItem
    {
        string Name { get; }
        
        Sprite Sprite { get; }
        float Weight { get; }
        int MaxStack { get; }
        void Accept(IItemVisitor itemVisitor);
    }
}