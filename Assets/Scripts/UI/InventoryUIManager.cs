using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : SingletonBehaviour<InventoryUIManager> {
    public GameObject Panel_Inventory;

    public GameObject Panel_ActionView;
    public GameObject Panel_ActionCook;
    public GameObject Panel_ActionSell;
    //public GameObject[] Tabs;

    public GameObject Content_ItemHandlerRaw;
    //public GameObject Pref_EmptySlotFail;

    private PanelItem panelAction;
    private OwnedItem CurrentSelectedOwnedItem;

    public List<GameObject> GO_RawItemsList = new List<GameObject>();
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Panel_Inventory.SetActive(!Panel_Inventory.activeSelf);
            Panel_ActionView.SetActive(true);
            Panel_ActionCook.SetActive(false);
            Panel_ActionSell.SetActive(false);
            panelAction = Panel_ActionView.GetComponent<PanelItemView>();
            panelAction.ClearAllPreset();
            SelectFirstItem();
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            InventoryManager.Instance().SortItem();
            InventoryManager.Instance().UIRender();
            SelectFirstItem();
        }
    }

    public void ShowPanel(string reason) {
        switch (reason) {
            case "toCook":
                Panel_Inventory.SetActive(!Panel_Inventory.activeSelf);
                Panel_ActionSell.SetActive(false);
                Panel_ActionView.SetActive(false);
                Panel_ActionCook.SetActive(true);
                panelAction = Panel_ActionCook.GetComponent<PanelItemCook>();
                panelAction.ClearAllPreset();
                SelectFirstItem();
                break;
            case "toSell":
                Panel_Inventory.SetActive(!Panel_Inventory.activeSelf);
                Panel_ActionCook.SetActive(false);
                Panel_ActionView.SetActive(false);
                Panel_ActionSell.SetActive(true);
                //panelAction = Panel_ActionSell.GetComponent<PanelItemSell>();
                //panelAction.ClearAllPreset();
                SelectFirstItem();
                break;
            default:
                break;

        }
    }

    public void CreateItems(List<OwnedItem> OwnedItems) {
        RemovedAllItem();
        foreach (OwnedItem ele in OwnedItems) {
            if (ele.item.cookingStatus == ItemInfo.CookingStatus.Raw) {
                AddItems(ele);
            }
        }
        FailEmpty();
    }

    public OwnedItem GetCurrentSelectedOwnedItem() {
        return CurrentSelectedOwnedItem;
    }
    public void ShowItemDetail(OwnedItem ownedItem) {
        DeselectAllFrame();
        SearchItemByOwnedItem(ownedItem).GetComponent<UI_SlotItem>().ActiveSelectedFrame();
        CurrentSelectedOwnedItem = ownedItem;
        panelAction.Init(ownedItem);
    }

    private void RemovedAllItem() { // cooked will add later
        while (Content_ItemHandlerRaw.transform.childCount > 0) {
            DestroyImmediate(Content_ItemHandlerRaw.transform.GetChild(0).gameObject);
        }
        GO_RawItemsList = new List<GameObject>();
    }
    private void AddItems(OwnedItem ownedItem) {
        GameObject OuterFrame = Instantiate(ownedItem.item.OuterFrameGO, transform.position, Quaternion.identity);
        OuterFrame.GetComponent<UI_SlotItem>().SetOwnedItem(ownedItem);
        OuterFrame.transform.SetParent(Content_ItemHandlerRaw.transform, false);
        GO_RawItemsList.Add(OuterFrame);
    }
    private void FailEmpty() { // cooked will add later
        int childCount = Content_ItemHandlerRaw.transform.childCount;
        if (childCount < 35) {
            for (int i = 0; i < 35 - childCount; i++) {
                GameObject OuterFrame = Instantiate(RLOADER.GO_EMPTY_FRAME, transform.position, Quaternion.identity);
                OuterFrame.transform.SetParent(Content_ItemHandlerRaw.transform, false);
            }
        } else {
            for (int i = 0; i < 7 - (childCount % 7); i++) {
                GameObject OuterFrame = Instantiate(RLOADER.GO_EMPTY_FRAME, transform.position, Quaternion.identity);
                OuterFrame.transform.SetParent(Content_ItemHandlerRaw.transform, false);
            }
        }
    }

    private void SelectFirstItem() {
        DeselectAllFrame();
        if (GO_RawItemsList.Count > 0) {
            GO_RawItemsList[0].GetComponent<UI_SlotItem>().ActiveSelectedFrame();
            CurrentSelectedOwnedItem = GO_RawItemsList[0].GetComponent<UI_SlotItem>().GetOwnedItem();
            panelAction.Init(CurrentSelectedOwnedItem);
        }
    }
    private void DeselectAllFrame() {
        foreach (GameObject ele in GO_RawItemsList) {
            ele.GetComponent<UI_SlotItem>().DeactiveSelectedFrame();
        }
    }
    private GameObject SearchItemByOwnedItem(OwnedItem ownedItem) {
        foreach (GameObject ele in GO_RawItemsList) {
            if (ele.GetComponent<UI_SlotItem>().GetOwnedItem().item.ItemCode == ownedItem.item.ItemCode) {
                return ele;
            }
        }
        return null;
    }

    public void BTN_CloseInventory() {
        Panel_Inventory.SetActive(false);
    }
}
