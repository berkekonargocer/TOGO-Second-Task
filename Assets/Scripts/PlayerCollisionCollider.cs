using UnityEngine;

public class PlayerCollisionCollider : MonoBehaviour
{
    Inventory playerInventory;

    void Awake() {
        playerInventory = GetComponent<Inventory>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("PickableContainer")) 
        {
            if (playerInventory.GetItem() != null)
                return;

            IPickable pickable = collision.gameObject.GetComponentInChildren<IPickable>();
            pickable.Pickup(transform);
            playerInventory.AddItem(pickable);
        }
    }
}