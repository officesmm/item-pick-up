using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : SingletonBehaviour<InventoryManager> {
    private List<OwnedItem> ownedItems = new List<OwnedItem>();

    public void AddOwnedItem(ItemInfo item) {
        OwnedItem currentItem = SearchItem(item);
        if (currentItem != null) {
            currentItem.AddOwnedItem();
        }
        else {
            ownedItems.Add(new OwnedItem(item, 1));
        }

        UIRender();
    }

    public void RemoveItem(ItemInfo item) {
        OwnedItem currentItem = SearchItem(item);
        if (currentItem != null) {
            bool isRemain = currentItem.RemoveOwnedItem();
            if (!isRemain) {
                ownedItems.Remove(currentItem);
            }
        }
        else {
            Debug.Log("This item is not in the inventory");
        }
    }

    public OwnedItem SearchItem(ItemInfo item) {
        for (int j = 0; j < ownedItems.Count; j++) {
            if (item.ItemCode == ownedItems[j].item.ItemCode) {
                return ownedItems[j];
            }
        }
        return null;
    }
    
    public ItemInfo SearchItemByID(int itemID) {
        for (int j = 0; j < RLOADER.RAW_ITEMS_LIST.Length; j++) {
            if (RLOADER.RAW_ITEMS_LIST[j].ItemCode == itemID) {
                return RLOADER.RAW_ITEMS_LIST[j];
            }
        }
        return null;
    }

    public void SortItem() {
        for (int i = 0; i < ownedItems.Count; i++) {
            for (int j = 0; j < ownedItems.Count - 1; j++) {
                if (ownedItems[j].item.ItemCode > ownedItems[j + 1].item.ItemCode) {
                    OwnedItem temp = ownedItems[j];
                    ownedItems[j] = ownedItems[j + 1];
                    ownedItems[j + 1] = temp;
                }
            }
        }
    }

    public void Cooking(List<int> PreCookItemsList) {
        for (int i = 0; i < RLOADER.COOKED_ITEMS_LIST.Length; i++) {
            if (PreCookItemsList.AreListsEqual(RLOADER.COOKED_ITEMS_LIST[i].RequiredItemIDList)) {
                AddOwnedItem(RLOADER.COOKED_ITEMS_LIST[i]);
                foreach (int ele in PreCookItemsList) {
                    RemoveItem(SearchItemByID(ele));
                }
                break;
            }
        }
        UIRender();
    }

    public void UIRender() {
        InventoryUIManager.Instance().CreateItems(ownedItems);
    }
}