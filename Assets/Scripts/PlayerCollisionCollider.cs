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
            pickable.Pickup(itemCarryPosition);
            pickable.transform.localPosition = Vector3.zero;
            _playerInventory.AddItem(pickable);
        }
    }
}