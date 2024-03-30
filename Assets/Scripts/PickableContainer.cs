using System.Collections.Generic;
using UnityEngine;

public class PickableContainer : MonoBehaviour
{
    public List<IPickable> Items { get; private set; } = new List<IPickable>();


    private void Awake() {
        IPickable[] items = GetComponentsInChildren<IPickable>();
        Items.AddRange(items);
    }

    public IPickable TakePickable() {
        if (Items.Count == 0)
            return null;

        int rng = Random.Range(0, Items.Count);
        IPickable item = Items[rng];
        Items.Remove(item);
        return item;
    }
}