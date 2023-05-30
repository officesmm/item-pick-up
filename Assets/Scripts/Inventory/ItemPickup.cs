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
            }
        }
    }

    private void InteractAction(GameObject currentInteractable) {
        if (currentInteractable) {
            Item i = currentInteractable.GetComponent<Item>();
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (i.item.category == ItemInfo.Category.Pick) {
                    InventoryManager.Instance().AddItem(i);
                    Debug.Log(i.item.category + " : " + i.item.name);
                    i.RemoveItem();
                } else if (i.item.category == ItemInfo.Category.Cook) {
                    UIManager.Instance().ShowPanel("toCook");
                } else if (i.item.category ==   ItemInfo.Category.Sell) {
                    UIManager.Instance().ShowPanel("toSell");
                } else if (i.item.category == ItemInfo.Category.Door) {
                    i.Action();
                } else if (i.item.category == ItemInfo.Category.Rotate) {
                    i.Action();
                }

            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, PackableRadius);
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
}
