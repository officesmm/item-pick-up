using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelItemSell : PanelItem {
    public TMP_Text TXT_Price;
    public Button BTN_Sell;
    public Button BTN_Cancel;

    private void Awake() {
        BTN_Sell.onClick.AddListener(delegate { OnClickSelling(); });
    }
    
    public override void OnClickedDisplay() {
        base.OnClickedDisplay();
        TXT_Price.text = m_OwnedItem.item.Cost.ToString();
    }

    private void OnClickSelling() {
        // remove item    
        // Sent addint money to moneyManager 
    }
}