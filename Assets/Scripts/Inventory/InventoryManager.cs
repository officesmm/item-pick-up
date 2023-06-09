using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonBehaviour<InventoryManager> {
    private List<OwnedItem> ownedItems = new List<OwnedItem>();
    private List<CookedItem> cookedItems = new List<CookedItem>();

    public void AddItem(Item item) {
        OwnedItem currentItem = SearchItem(item); 
        if (currentItem != null) {
            currentItem.AddOwnedItem();
        } 
        else {
            ownedItems.Add(new OwnedItem(item, 1));
        }
        UIRenender();
    }

    public void RemoveItem(Item item) {
        OwnedItem currentItem = SearchItem(item);
        if (currentItem != null) {
            bool isRemain = currentItem.RemoveOwnedItem();
            if (!isRemain) {
                ownedItems.Remove(currentItem);
            }
        } else {
            Debug.Log("This item is not in the inventory");
        }
    }

    public OwnedItem SearchItem(Item item) {
        for (int j = 0; j < ownedItems.Count; j++) {
            if (item.item.ItemCode == ownedItems[j].item.item.ItemCode) {
                return ownedItems[j];
            }
        }
        return null;
    }
    public void SortItem() {
        for (int i = 0; i < ownedItems.Count; i++) {
            for (int j = 0; j < ownedItems.Count - 1; j++) {
                if (ownedItems[j].item.item.ItemCode > ownedItems[j+1].item.item.ItemCode) {
                    OwnedItem temp = ownedItems[j];
                    ownedItems[j] = ownedItems[j + 1];
                    ownedItems[j + 1] = temp;
                }
            }
        }
    }
    
    public void UIRenender() {
        InventoryUIManager.Instance().CreateItems(ownedItems);
    }
}
