using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelItemView : PanelItem {
    public GameObject Panel_ItemEffect;
    public GameObject Pref_SlotItemEffect;
    public override void OnClickedDisplay() {
        base.OnClickedDisplay();
        while (Panel_ItemEffect.transform.childCount > 0) {
            DestroyImmediate(Panel_ItemEffect.transform.GetChild(0).gameObject);
        }
        GameObject GO_SlotItemEffect = Instantiate(Pref_SlotItemEffect, transform.position, Quaternion.identity);
        GO_SlotItemEffect.transform.SetParent(Panel_ItemEffect.transform, false);
        GO_SlotItemEffect.GetComponent<UI_SlotItemEffect>().Init(
            m_OwnedItem.item.item.ItemEffectList[0].EffectIcon,
            m_OwnedItem.item.item.ItemEffectList[0].EffectTitle,
            m_OwnedItem.item.item.ItemEffectList[0].EffectDescription
            );
    }
}
