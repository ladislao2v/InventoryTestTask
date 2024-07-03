using Code.Services.ItemUser;
using UnityEngine;

namespace Code.Model.Items
{
    [CreateAssetMenu(menuName = "Create HeadArmor", fileName = "HeadArmor", order = 0)]
    public class HeadArmor : Armor
    {
        public override void Accept(IItemVisitor itemVisitor) => 
            itemVisitor.Visit(this);
    }
}