using UnityEngine;

[DisallowMultipleComponent]
public class Item : MonoBehaviour, IPickable
{
    public Color ObjectColor { get { return objectColor; } }
    [SerializeField] Color objectColor;
    
    public ItemColor Color { get { return color; } }

    [SerializeField] ItemColor color;


    public void Place(Transform parent) {
        SetParent(parent);
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    private void Awake() {
        Material material = GetComponent<Renderer>().material;
        material.color = objectColor;
    }

    void SetParent(Transform parent) {
        gameObject.transform.parent = parent;
    }
}