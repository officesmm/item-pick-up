using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;  

public class Item : MonoBehaviour {
    public ItemInfo item;
    public TMP_Text text;

    private void Awake() {
        Init();
    }
    public void Init() {
        text.text = "";
    }

    public void RemoveItem() {
        Destroy(gameObject);
    }
    public void ShowHighlight() {
        text.text = item.ItemName;
    }
    public void HideHighlight() {
        text.text = "";
    }
    public virtual void Action(GameObject player) {}
}
