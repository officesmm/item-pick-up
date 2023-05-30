using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotItem : MonoBehaviour {

    public Image imageFrame;
    public Image imageIcon;
    public TMP_Text textItemCount;

    ItemInfo m_ItemInfo;

    public void SetItemInfo(ItemInfo itemInfo) {
        m_ItemInfo = itemInfo;
        SetOuterFrame();
        SetUIFrame();
    }

    private void SetOuterFrame() {
        imageFrame.sprite = m_ItemInfo.ItemFrame;
    }

    private void SetUIFrame() {
        imageIcon.sprite = m_ItemInfo.ItemIcon;
    }
    public void SetCount(int i) {
        textItemCount.text = i.ToString();
    }
}
