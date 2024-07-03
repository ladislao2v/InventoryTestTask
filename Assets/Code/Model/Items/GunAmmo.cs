using Code.Services.ItemUser;
using UnityEngine;

namespace Code.Model.Items
{
    [CreateAssetMenu(menuName = "Create GunAmmo", fileName = "GunAmmo", order = 0)]
    public class GunAmmo : Ammo
    {
        public override void Accept(IItemVisitor itemVisitor) => 
            itemVisitor.Visit(this);
    }
}