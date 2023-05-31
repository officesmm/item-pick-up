using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager> {
    public GameObject Panel_Inventory;

    public GameObject Panel_ActionView;
    public GameObject Panel_ActionCook;
    public GameObject Panel_ActionSell;
    //public GameObject[] Tabs;

    public GameObject Content_ItemHandlerRaw;
    public GameObject Pref_EmptySlotFail;

    private PanelItem panelAction;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Panel_Inventory.SetActive(!Panel_Inventory.activeSelf);
            Panel_ActionCook.SetActive(false);
            Panel_ActionSell.SetActive(false);
            panelAction = Panel_ActionView.GetComponent<PanelItemView>();
        }
    }

    public void ShowPanel(string reason) {
        switch (reason) {
            case "toCook":
                Panel_Inventory.SetActive(!Panel_Inventory.activeSelf);
                Panel_ActionSell.SetActive(false);
                Panel_ActionCook.SetActive(true);
                break;
            case "toSell":
                Panel_Inventory.SetActive(!Panel_Inventory.activeSelf);
                Panel_ActionCook.SetActive(false);
                Panel_ActionSell.SetActive(true);
                break;
            default:
                break;

        }
    }

    public void CreateItems(List<OwnedItem> OwnedItems) {
        RemovedAll();
        foreach (OwnedItem ele in OwnedItems) {
            AddItems(ele);
        }
        FailEmpty();
    }

    private void RemovedAll() { // cooked will add later
        while (Content_ItemHandlerRaw.transform.childCount > 0) {
            DestroyImmediate(Content_ItemHandlerRaw.transform.GetChild(0).gameObject);
        }
    }
    private void FailEmpty() { // cooked will add later
        for (int i = 0; i < 7 - (Content_ItemHandlerRaw.transform.childCount % 7); i++) {
            GameObject OuterFrame = Instantiate(Pref_EmptySlotFail, transform.position, Quaternion.identity);
            OuterFrame.transform.SetParent(Content_ItemHandlerRaw.transform, false);
        }
        
    }
    private void AddItems(OwnedItem ownedItem) {
        GameObject OuterFrame = Instantiate(ownedItem.item.item.OuterFrameGO, transform.position, Quaternion.identity);
        OuterFrame.GetComponent<UI_SlotItem>().SetOwnedItem(ownedItem);
        OuterFrame.transform.SetParent(Content_ItemHandlerRaw.transform, false);
    }

    public void ShowItemDetail(OwnedItem ownedItem) {
        panelAction.Init(ownedItem);
    }
}
