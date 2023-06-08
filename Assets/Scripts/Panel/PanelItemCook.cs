using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelItemCook : PanelItem {
    public UI_SlotCook[] uI_SlotCook;
    public override void OnClickedDisplay() {
        base.OnClickedDisplay();
    }
    public override void ClearAllPreset() {
        base.ClearAllPreset();
        foreach (UI_SlotCook ele in uI_SlotCook) {
            ele.ClearSlot();
        }
    }
}
