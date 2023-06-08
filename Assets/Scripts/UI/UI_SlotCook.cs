using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotCook : MonoBehaviour {
    
    public ItemInfo.FrameCategory SlotFrameCategory;
    public Image IMG_Icon;
    public Button BTN_Action;
    public GameObject GO_SignAdd;
    public GameObject GO_SignRemove;

    private OwnedItem PreCookItemAdded = null;

    private bool added = false;
    private Color tempColor = new Color();
    private void Start() {
        PreCookItemAdded = null;
        added = false;
        tempColor.a = 0;
        BTN_Action.onClick.AddListener(delegate { OnClickAddorRemove(); });
    }
    private void OnClickAddorRemove() {
        OwnedItem selectedItem = InventoryUIManager.Instance().GetCurrentSelectedOwnedItem();
        
        if (selectedItem != null) {
            if (SlotFrameCategory == selectedItem.item.item.frameCategory) {
                if (!added) {
                    PreCookItemAdded = selectedItem;
                    IMG_Icon.sprite = PreCookItemAdded.item.item.ItemIcon;
                    IMG_Icon.color = Color.white;
                    GO_SignAdd.SetActive(false);
                    GO_SignRemove.SetActive(true);
                    added = true;
                } else {
                    ClearSlot();
                }
            } else {
                if (!added) {
                    Debug.Log("No allow to add");
                } else {
                    ClearSlot();
                }
            }
        } else {
            Debug.Log("Nothing is selected");
        }
    }

    public OwnedItem GetPreCookItemAdded() {
        return PreCookItemAdded;
    }

    public void ClearSlot() {
        PreCookItemAdded = null;
        IMG_Icon.sprite = null;
        IMG_Icon.color = tempColor;
        GO_SignAdd.SetActive(true);
        GO_SignRemove.SetActive(false);
        added = false;
    }

}
