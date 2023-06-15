using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CookedItemInfo", menuName = "ScriptableObjects/CookedItemInfo", order = 1)]
public class CookedItemInfo : ItemInfo {
    public List<int> RequiredItemIDList;
}