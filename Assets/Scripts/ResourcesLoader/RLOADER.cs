using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLOADER : MonoBehaviour {

    //GAME_OBJECT
    public static GameObject GO_EMPTY_FRAME;
    //UI_PANEL

    //SPRITE
    public static Sprite SPRITE_EMPTY_FRAME;
    
    public static CookedItemInfo[]  RAW_ITEMS_LIST;
    public static CookedItemInfo[]  COOKED_ITEMS_LIST;
    void Awake() {
        //GAME_OBJECT
        GO_EMPTY_FRAME = Resources.Load<GameObject>("UIPrefabs/UI_Slot_Empty");

        //UI_PANEL

        //SPRITE
        SPRITE_EMPTY_FRAME = Resources.Load<Sprite>("Sprites/Frame_ItemFrame01_Empty");

        //SCRIPTABLE_OBJECT 
        RAW_ITEMS_LIST = Resources.LoadAll<CookedItemInfo>("Sprites/Items/Raw");
        COOKED_ITEMS_LIST = Resources.LoadAll<CookedItemInfo>("Sprites/Items/Cooked");

    }
}
