using UnityEngine;


public class Item : MonoBehaviour, IPickable
{
    [field: SerializeField] Color ItemColor { get; set; }

    public ItemColor Color { get { return color; } }

    [SerializeField] ItemColor color;


    public void Place(Transform parent) {
        SetParent(parent);
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    private void Awake() {
        gameObject.GetComponent<Renderer>().material.color = ItemColor;
    }

    void SetParent(Transform parent) {
        gameObject.transform.parent = parent;
    }
}