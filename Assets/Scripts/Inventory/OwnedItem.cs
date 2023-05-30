using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedItem{
    public Item item;
    public int count;
    public string status;
    public OwnedItem(Item item, int count) {
        this.item = item;
        this.count = count;
    }
}
