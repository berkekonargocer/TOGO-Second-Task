using UnityEngine;

public class Inventory : MonoBehaviour
{
    Transform item0;

    Transform GetItem() {
        return item0;
    }

    void SetItem(Transform item) {
        item0 = item;
    }
}
