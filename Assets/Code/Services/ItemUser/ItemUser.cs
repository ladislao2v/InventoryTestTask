using Code.Model.Inventory;
using Code.Model.Items;
using Code.Model.Units;
using Code.Model.Visitors.Items;

namespace Code.Services.ItemUser
{
    public class ItemUser : IItemUser
    {
        private readonly IItemVisitor _itemVisitor;

        public ItemUser(Player player, IInventory inventory)
        {
            _itemVisitor = new ItemUseVisitor(player, inventory);
        }
        
        public void Use(IItem item)
        {
            item.Accept(_itemVisitor);
        }
    }
}