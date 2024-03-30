using System;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemPlaceContainer : MonoBehaviour
{
    [SerializeField] Transform[] items;
    [SerializeField] ItemColor itemToPlaceColor;

    int _currentIndex = 0;

    public event Action OnPlacedCorrect;
    public event Action OnPlacedWrong;

    public void Place(IPickable item) {
        item.Place(items[_currentIndex].transform);
        _currentIndex++;

        if (item.Color == itemToPlaceColor)
        {
            OnPlacedCorrect?.Invoke();
            Debug.Log("CORRECT");
            return;
        }

        Debug.Log("WRONG");
        OnPlacedWrong?.Invoke();
    }
}