using UnityEngine;

public class Inventory : MonoBehaviour
{
    IPickable item0;

    public IPickable GetItem() {
        return item0;
    }

    public void AddItem(IPickable item) {
        item0 = item;
    }

    public void RemoveItem() {
        item0 = null;
    }
}