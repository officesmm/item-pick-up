using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_SlotItemEffect : MonoBehaviour {
    public Image IMG_ItemEffect;
    public TMP_Text TMP_ItemEffectTitle;
    public TMP_Text TMP_ItemEffectDescription;
    
    public void Init(Sprite icon, string title, string description) {
        IMG_ItemEffect.sprite = icon;
        TMP_ItemEffectTitle.text = title;
        TMP_ItemEffectDescription.text = description;
    }
}
