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

    private void Start() {
        added = false;
        PreCookItemAdded = null;
        BTN_Action.onClick.AddListener(delegate { OnClickAddorRemove(); });
    }
    private void OnClickAddorRemove() {
        OwnedItem selectedItem = UIManager.Instance().GetCurrentSelectedOwnedItem();
        if (selectedItem != null) {
            if (SlotFrameCategory == selectedItem.item.item.frameCategory) {
                if (!added) {
                    PreCookItemAdded = selectedItem;
                    GO_SignAdd.SetActive(false);
                    GO_SignRemove.SetActive(true);
                    added = true;
                } else {
                    PreCookItemAdded = null;
                    GO_SignAdd.SetActive(true);
                    GO_SignRemove.SetActive(false);
                    added = false;
                }
            } 
            else {
                if (!added) {
                    Debug.Log("No allow to add");
                } else {
                    PreCookItemAdded = null;
                    GO_SignAdd.SetActive(true);
                    GO_SignRemove.SetActive(false);
                    added = false;
                }
            } 
        }
    }

    public OwnedItem GetPreCookItemAdded() {
        return PreCookItemAdded;
    }

}
