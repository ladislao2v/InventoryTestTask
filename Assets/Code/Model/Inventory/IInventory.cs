using Code.Model.Items;
using Code.Services.SaveLoadDataService;
using UniRx;

namespace Code.Model.Inventory
{
    public interface IInventory
    {
        float Weight { get; }
        bool IsEmpty { get; }
        IReactiveCollection<ISlot> Slots { get; }
        void Add(IItem item, int count = 1);
        void Remove(IItem item);
        bool TryFindSlot(IItem item, out ISlot slot);
    }
}