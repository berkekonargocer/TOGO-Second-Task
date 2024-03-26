using UnityEngine;

public class PlayerCollisionCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Pickable")) 
        {
            IPickable pickable = collision.gameObject.GetComponent<IPickable>();
            pickable.Pickup();
        }
    }
}