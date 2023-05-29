using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonBehaviour<InventoryManager> {
    private List<Item> items = new List<Item>();
    private List<CookedItem> cookedItems = new List<CookedItem>();


    public void AddItem(Item item) {
        items.Add(item);
    }

    public Item SearchItem(Item item) {
        for (int j = 0; j < items.Count; j++) {
            if (item.item.ItemCode == items[j].item.ItemCode) {
                return items[j];
            }
        }
        return null;
    }

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
