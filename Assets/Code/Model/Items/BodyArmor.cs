using Code.Services.ItemUser;
using UnityEngine;

namespace Code.Model.Items
{
    [CreateAssetMenu(menuName = "Create BodyArmor", fileName = "BodyArmor", order = 0)]
    public class BodyArmor : Armor
    {
        public override void Accept(IItemVisitor itemVisitor)
        {
            itemVisitor.Visit(this);
        }
    }
}