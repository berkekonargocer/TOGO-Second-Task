using UnityEngine;


public interface IPickable
{
    GameObject gameObject { get; }
    Transform transform { get; }
    public void Pickup(Transform parent);
}