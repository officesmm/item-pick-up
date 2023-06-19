using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    public float PackableRadius = 1.0f;

    void Update() {
        RaycastHit2D[] allInteractable = Physics2D.CircleCastAll(transform.position, PackableRadius, Vector2.zero);
        foreach (RaycastHit2D ele in allInteractable) {
            if (ele.collider.tag == "interact") {
                InteractAction(ele.collider.gameObject);
                break;
            }
        }
    }

    private void InteractAction(GameObject currentInteractable) {
        if (currentInteractable) {
            Item i = currentInteractable.GetComponent<Item>();
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (i.item.category == ItemInfo.Category.Pick) {
                    InventoryManager.Instance().AddOwnedItem(i.item);
                    InventoryManager.Instance().UIRender();
                    i.RemoveItem();
                } else if (i.item.category == ItemInfo.Category.Cook) {
                    InventoryUIManager.Instance().ShowPanel("toCook");
                } else if (i.item.category ==   ItemInfo.Category.Sell) {
                    InventoryUIManager.Instance().ShowPanel("toSell");
                } else if (i.item.category == ItemInfo.Category.Interaction) {
                    i.Action(gameObject);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "interact") {
            collision.GetComponent<Item>().ShowHighlight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "interact") {
            collision.GetComponent<Item>().HideHighlight();
        }
    }   
    
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, PackableRadius);
    }
}
