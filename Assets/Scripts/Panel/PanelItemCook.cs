using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelItemCook : PanelItem {
    public UI_SlotCook[] uI_SlotCook;
    public Button BTN_Cook;
    public Button BTN_Cancel;

    private void Awake() {
        BTN_Cook.onClick.AddListener(delegate { OnClickCooking(); });
    }

    public override void ClearAllPreset() {
        base.ClearAllPreset();
        ClearSlotCook();
    }

    private void OnClickCooking() {
        List<int> ItemIDList = new List<int>();
        foreach (UI_SlotCook ele in uI_SlotCook) {
            if (ele.GetPreCookItemAdded().item.ItemCode != null) {
                ItemIDList.Add(ele.GetPreCookItemAdded().item.ItemCode);
            }
        }
        InventoryManager.Instance().Cooking(ItemIDList);
    }

    private void ClearSlotCook() {
        foreach (UI_SlotCook ele in uI_SlotCook) {
            ele.ClearSlot();
        }
    }
}