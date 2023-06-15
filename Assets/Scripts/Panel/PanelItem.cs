using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelItem : MonoBehaviour {
    public GameObject GO_ItemSlot;
    public Image IMG_OuterFrame;
    public Image IMG_ItemImage;
    public TMP_Text TMP_ItemCount;

    public TMP_Text TMP_ItemCategory;
    public TMP_Text TMP_ItemName;
    public TMP_Text TMP_ItemDescription;

    protected OwnedItem m_OwnedItem;
    public void Init(OwnedItem OwnedItem) {
        m_OwnedItem = OwnedItem;
        OnClickedDisplay();
    }
    public virtual void OnClickedDisplay() {
        IMG_OuterFrame.sprite = m_OwnedItem.item.OuterFrameImage;
        IMG_ItemImage.sprite = m_OwnedItem.item.ItemIcon;
        TMP_ItemCount.text = m_OwnedItem.count.ToString();

        TMP_ItemCategory.text = m_OwnedItem.item.category.ToString();
        TMP_ItemName.text = m_OwnedItem.item.ItemName;
        TMP_ItemDescription.text = m_OwnedItem.item.ItemDescription;
    }

    public virtual void ClearAllPreset() {
        IMG_OuterFrame.sprite = RLOADER.SPRITE_EMPTY_FRAME;
        IMG_ItemImage.sprite = RLOADER.SPRITE_EMPTY_FRAME;
        TMP_ItemCount.text = "";
        TMP_ItemCategory.text = "";
        TMP_ItemName.text = "";
        TMP_ItemDescription.text = "";
    }
}
