
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/ItemInfo", order = 1)]
public class ItemInfo : ScriptableObject {
    //BasicInfo
    public enum Category { Pick, Door, Rotate, Cook, Sell}
    public Category category;
    public string ItemName;
    public int ItemCode;

    //UI
    public GameObject OuterFrame;
    public Sprite ItemFrame;
    public Sprite ItemIcon;
    public string ItemDescription;
    public List<ItemEffectInfo> ItemEffectList;
    public int Cost;

}
