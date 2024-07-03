using Code.Model.Items;

namespace Code.Services.ItemUser
{
    public interface IItemVisitor
    {
        void Visit(Ammo ammo);
        void Visit(HeadArmor armor);
        void Visit(BodyArmor armor);
        void Visit(MedicineKit kit);
    }
}