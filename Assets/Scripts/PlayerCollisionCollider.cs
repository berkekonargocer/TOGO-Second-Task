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

            PickableContainer pickableContainer = collision.gameObject.GetComponentInParent<PickableContainer>();
            IPickable pickable = pickableContainer.TakePickable();

            if (pickable == null)
                return;

            PickupItem(pickable);
        }

        if (collision.gameObject.CompareTag("ItemPlaceContainer"))
        {
            if (_playerInventory.GetItem() == null)
                return;

            ItemPlaceContainer container = collision.gameObject.GetComponentInParent<ItemPlaceContainer>();
            PlaceItem(container);
        }
    }

    void PickupItem(IPickable pickable) {
        pickable.Place(itemCarryPosition);
        _playerInventory.AddItem(pickable);
    }

    void PlaceItem(ItemPlaceContainer container) {
        container.Place(_playerInventory.TakeItem());
    }
}