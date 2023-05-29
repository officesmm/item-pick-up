using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffectInfo", menuName = "ScriptableObjects/ItemEffectInfo", order = 1)]
public class ItemEffectInfo : ScriptableObject{
    public Sprite EffectIcon;
    public string EffectTitle;
    public string EffectDescription;
}
