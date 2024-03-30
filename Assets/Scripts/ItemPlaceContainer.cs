using System;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemPlaceContainer : MonoBehaviour
{
    [SerializeField] Transform[] items;
    [SerializeField] ItemColor itemToPlaceColor;

    int _currentPlaceIndex = 0;

    public int CorrectPlacement { get; private set; } = 0;
    public int WrongPlacement { get; private set; } = 0;

    public event Action OnPlacedCorrect;
    public event Action OnPlacedWrong;


    public void Place(IPickable item) {
        item.Place(items[_currentPlaceIndex].transform);
        _currentPlaceIndex++;

        if (item.Color == itemToPlaceColor)
        {
            CorrectPlacement++;
            OnPlacedCorrect?.Invoke();
            return;
        }

        WrongPlacement++;
        OnPlacedWrong?.Invoke();
    }

    private void OnCollisionEnter(Collision collision) {
        Inventory playerInventory = collision.gameObject.GetComponent<Inventory>();
        PlayerMaterial playerMaterial = collision.gameObject.GetComponent<PlayerMaterial>();

        if (playerInventory.GetItem() == null)
            return;

        Place(playerInventory.TakeItem());
        playerMaterial.ChangeHeadMaterialColor(Color.white);
    }
}