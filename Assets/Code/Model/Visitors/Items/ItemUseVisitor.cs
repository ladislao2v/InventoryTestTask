using Code.Model.Inventory;
using Code.Model.Items;
using Code.Model.Units;
using Code.Services.ItemUser;

namespace Code.Model.Visitors.Items
{
    public class ItemUseVisitor : IItemVisitor
    {
        private readonly Player _player;
        private readonly IInventory _inventory;

        public ItemUseVisitor(Player player, IInventory inventory)
        {
            _player = player;
            _inventory = inventory;
        }

        public void Visit(Ammo ammo)
        {
            _inventory.Add(ammo, ammo.MaxStack);
        }

        public void Visit(HeadArmor armor) => 
            _player.Armor.AddHamlet(armor);

        public void Visit(BodyArmor armor) => 
            _player.Armor.AddBodyArmor(armor);

        public void Visit(MedicineKit kit)
        {
            if (!_inventory.TryFindSlot(kit, out ISlot slot))
                return;
            
            slot.RemoveCount(1);
            
            _player.Hill(kit.Hill);
        }
    }
}