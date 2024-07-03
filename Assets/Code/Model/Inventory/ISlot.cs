using Code.Model.Items;
using UniRx;

namespace Code.Model.Inventory
{
    public interface ISlot
    {
        IItem Item { get; }
        IReactiveProperty<int> Count { get; }

        float Weight { get; }

        void AddCount(int count);
        void RemoveCount(int count);
    }
}