using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField] Color ItemColor { get; set; }

    private void Awake() {
        gameObject.GetComponent<Renderer>().material.color = ItemColor;
    }

    Transform GetTransform() {
        return gameObject.transform;
    }
}
