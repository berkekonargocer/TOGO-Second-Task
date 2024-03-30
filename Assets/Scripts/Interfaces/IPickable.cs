using UnityEngine;


public interface IPickable
{
    GameObject gameObject { get; }
    Transform transform { get; }
    public ItemColor Color { get; }
    public void Place(Transform parent);
}