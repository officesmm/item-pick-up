using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedItem {
    public ItemInfo item;
    public int count;
    public string status;
    public OwnedItem(ItemInfo item, int count) {
        this.item = item;
        this.count = count;
    }
    public void AddOwnedItem() {
        this.count++;
    }
    public void AddOwnedItem(int count) {
        this.count += count;
    }

    public bool RemoveOwnedItem() {
        count--;
        if (count <= 0) {
            return false;
        } else {
            return true;
        }
    }
}
