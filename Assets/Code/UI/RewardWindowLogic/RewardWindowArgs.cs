using System.Collections.Generic;
using Code.Inventory;

namespace Code.UI.RewardWindowLogic
{
    public class RewardWindowArgs : WindowArgs
    {
        public string TitleText { get; private set; }
        public List<InventoryItem> InventoryItems { get; private set; }

        public RewardWindowArgs(string titleText, List<InventoryItem> inventoryItems)
        {
            TitleText = titleText;
            InventoryItems = inventoryItems;
        }
    }
}