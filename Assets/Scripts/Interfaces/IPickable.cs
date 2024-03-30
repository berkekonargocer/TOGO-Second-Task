using UnityEngine;


public interface IPickable
{
    GameObject gameObject { get; }
    Transform transform { get; }
    public ItemColor Color { get; }
    public Color ObjectColor { get; }
    public void Place(Transform parent);
}