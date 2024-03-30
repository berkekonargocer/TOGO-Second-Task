using System.Collections.Generic;
using UnityEngine;

public class PickableContainer : MonoBehaviour
{
    List<IPickable> _items = new List<IPickable>();


    private void Awake() {
        IPickable[] items = GetComponentsInChildren<IPickable>();
        _items.AddRange(items);
    }

    public IPickable TakePickable() {
        if (_items.Count == 0)
            return null;

        int rng = Random.Range(0, _items.Count);
        IPickable item = _items[rng];
        _items.Remove(item);
        return item;
    }
}