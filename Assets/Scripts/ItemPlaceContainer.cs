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
            Debug.Log("CORRECT");
            return;
        }

        Debug.Log("WRONG");
        WrongPlacement++;
        OnPlacedWrong?.Invoke();
    }
}