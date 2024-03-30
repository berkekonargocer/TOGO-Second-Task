using System.Collections.Generic;
using UnityEngine;

public class PickableContainer : MonoBehaviour
{
    public List<IPickable> Items { get; private set; } = new List<IPickable>();


    private void Awake() {
        IPickable[] items = GetComponentsInChildren<IPickable>();
        Items.AddRange(items);
    }

    public IPickable TakePickable() {
        if (Items.Count == 0)
            return null;

        int rng = Random.Range(0, Items.Count);
        IPickable item = Items[rng];
        Items.Remove(item);
        return item;
    }
    void PickupItem(IPickable pickable, Inventory inventory) {
        pickable.Place(inventory.itemCarryPosition);
        inventory.AddItem(pickable);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Inventory playerInventory = collision.gameObject.GetComponent<Inventory>();

            if (playerInventory.GetItem() != null || Items.Count <= 0)
                return;

            IPickable pickable = TakePickable();
            PickupItem(pickable, playerInventory);
        }
    }

}