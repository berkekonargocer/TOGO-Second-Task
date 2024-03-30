using UnityEngine;

public class PlayerCollisionCollider : MonoBehaviour
{
    Inventory _playerInventory;

    [SerializeField] Transform itemCarryPosition;

    void Awake() {
        _playerInventory = GetComponent<Inventory>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("PickableContainer"))
        {
            if (_playerInventory.GetItem() != null)
                return;

            IPickable pickable = collision.gameObject.GetComponentInChildren<IPickable>();
            PickupItem(pickable);
        }

        if (collision.gameObject.CompareTag("ItemPlaceContainer"))
        {
            if (_playerInventory.GetItem() == null)
                return;

            ItemPlaceContainer container = collision.gameObject.GetComponent<ItemPlaceContainer>();
            PlaceItem(container);
        }
    }

    void PickupItem(IPickable pickable) {
        pickable.Place(itemCarryPosition);
        _playerInventory.AddItem(pickable);
    }

    void PlaceItem(ItemPlaceContainer container) {
        container.Place(_playerInventory.GetItem());
        _playerInventory.RemoveItem();
    }
}