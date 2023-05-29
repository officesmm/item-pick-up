using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager> {
    public GameObject panel;
    public GameObject[] Tabs;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void ShowPanel(string reason) {
        switch (reason) {
            case "toCook":

                break;
            case "toSell":

                break;
            default:
                break;

        }
    }
}
