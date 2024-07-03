using Code.Services.ItemUser;
using UnityEngine;

namespace Code.Model.Items
{
    [CreateAssetMenu(menuName = "Create PistolAmmo", fileName = "PistolAmmo", order = 0)]
    public class PistolAmmo : Ammo
    {
        public override void Accept(IItemVisitor itemVisitor) => 
            itemVisitor.Visit(this);
    }
}