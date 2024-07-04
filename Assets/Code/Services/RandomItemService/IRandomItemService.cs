using System;
using Code.Model.Items;
using Code.Services.AssetProvider;

namespace Code.Services.RandomItemService
{
    public interface IRandomItemService
    {
        IItem GetRandomItem();
    }
}