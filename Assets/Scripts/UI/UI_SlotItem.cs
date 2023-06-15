using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotItem : MonoBehaviour {

    public GameObject GO_SelectionFrame;
    public Image IMG_Frame;
    public Image IMG_Icon;
    public TMP_Text TXT_ItemCount;
    public Button BTN_Action;

    private OwnedItem m_OwnedItem;
    private void Start() {
        BTN_Action.onClick.AddListener(delegate { OnClickShowItemInfo(); });
    }

    public void SetOwnedItem(OwnedItem ownedItem) {
        m_OwnedItem = ownedItem;
        IMG_Frame.sprite = ownedItem.item.OuterFrameImage;
        IMG_Icon.sprite = ownedItem.item.ItemIcon;
        TXT_ItemCount.text = ownedItem.count.ToString();
    }

    private void OnClickShowItemInfo() {
        InventoryUIManager.Instance().ShowItemDetail(m_OwnedItem);
    }

    public OwnedItem GetOwnedItem() {
        return m_OwnedItem;
    }

    public void ActiveSelectedFrame() {
        GO_SelectionFrame.SetActive(true);
    }
    public void DeactiveSelectedFrame() {
        GO_SelectionFrame.SetActive(false);
    }
}