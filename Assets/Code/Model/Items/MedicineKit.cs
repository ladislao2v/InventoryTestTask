using Code.Services.ItemUser;
using UnityEngine;

namespace Code.Model.Items
{
    [CreateAssetMenu(menuName = "Create MedicineKit", fileName = "MedicineKit", order = 0)]
    public class MedicineKit : Item, IItem
    {
        [field: SerializeField] public int Hill { get; private set;}
        public override void Accept(IItemVisitor itemVisitor) => 
            itemVisitor.Visit(this);
    }
}