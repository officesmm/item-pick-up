using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonBehaviour<InventoryManager> {
    private List<OwnedItem> ownedItems = new List<OwnedItem>();
    private List<CookedItem> cookedItems = new List<CookedItem>();

    public void AddItem(Item item) {
        OwnedItem currentItem = SearchItem(item); // လက်ရှိ Item ကိုင်ထားလားရှာ 
        if (currentItem != null) { // ရှိရင်အရေအတွက်တိုး
            currentItem.count++;
        } 
        else { // မရှိရင် အသစ်ထည့်
            ownedItems.Add(new OwnedItem(item, 1));
        }
        UIRenender();
    }

    public OwnedItem SearchItem(Item item) {
        for (int j = 0; j < ownedItems.Count; j++) {
            if (item.item.ItemCode == ownedItems[j].item.item.ItemCode) {
                return ownedItems[j];
            }
        }
        return null;
    }

    public void UIRenender() {
        InventoryUIManager.Instance().CreateItems(ownedItems);
    }
}
