using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager> {
    public GameObject Panel;
    public GameObject PanelActionCook;
    public GameObject PanelActionSell;
    public GameObject[] Tabs;

    public GameObject ItemHandlerRawContent;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Panel.SetActive(!Panel.activeSelf);
            PanelActionCook.SetActive(false);
            PanelActionSell.SetActive(false);
        }
    }

    public void ShowPanel(string reason) {
        switch (reason) {
            case "toCook":
                Panel.SetActive(!Panel.activeSelf);
                PanelActionSell.SetActive(false);
                PanelActionCook.SetActive(true);
                break;
            case "toSell":
                Panel.SetActive(!Panel.activeSelf);
                PanelActionCook.SetActive(false);
                PanelActionSell.SetActive(true);
                break;
            default:
                break;

        }
    }

    public void CreateItems(List<OwnedItem> OwnedItems) {
        foreach (OwnedItem ele in OwnedItems) {
            RemovedAll();
            AddItems(ele);
        } 
    }

    private void RemovedAll() { // cooked will add later
        while (ItemHandlerRawContent.transform.childCount > 0) {
            DestroyImmediate(ItemHandlerRawContent.transform.GetChild(0).gameObject);
        }
    }
    private void AddItems(OwnedItem ownedItem) {
        GameObject OuterFrame = Instantiate(ownedItem.item.item.OuterFrame, transform.position, Quaternion.identity);
        OuterFrame.GetComponent<UI_SlotItem>().SetItemInfo(ownedItem.item.item);
        OuterFrame.GetComponent<UI_SlotItem>().SetCount(ownedItem.count);
        OuterFrame.transform.SetParent(ItemHandlerRawContent.transform, false);
    }
}
