
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/ItemInfo", order = 1)]
public class ItemInfo : ScriptableObject {
    //BasicInfo
    public enum Category { Pick, Interaction, Cook, Sell }
    public Category category;
    public enum FrameCategory { Liquid, Meal, Fruit }
    public FrameCategory frameCategory;
    public enum CookingStatus { Raw, Cooked }
    public CookingStatus cookingStatus = CookingStatus.Raw;
    public string ItemName;
    public int ItemCode;

    //UI
    public GameObject OuterFrameGO;
    public Sprite OuterFrameImage;
    public Sprite ItemIcon;
    public string ItemDescription;
    public List<ItemEffectInfo> ItemEffectList;
    public int Cost;

}
