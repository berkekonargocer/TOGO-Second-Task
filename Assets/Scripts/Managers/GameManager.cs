using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action OnWinGame;
    public event Action OnLoseGame;

    [SerializeField] PickableContainer pickableContainer;

    [SerializeField] ItemPlaceContainer greenTable;
    [SerializeField] ItemPlaceContainer redTable;


    [SerializeField] int failChance;

    int _totalPlaceableCount;

    void OnEnable() {
        greenTable.OnPlacedCorrect += CheckIfGameFinished;
        redTable.OnPlacedCorrect += CheckIfGameFinished;
        greenTable.OnPlacedWrong += CheckIfGameFinished;
        redTable.OnPlacedWrong += CheckIfGameFinished;

    }

    void OnDisable() {
        greenTable.OnPlacedCorrect -= CheckIfGameFinished;
        redTable.OnPlacedCorrect -= CheckIfGameFinished;
        greenTable.OnPlacedWrong -= CheckIfGameFinished;
        redTable.OnPlacedWrong -= CheckIfGameFinished;
    }

    private void Awake() {
        InitializeSingleton();
        _totalPlaceableCount = pickableContainer.Items.Count;
    }


    void InitializeSingleton() {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    void CheckIfGameFinished() {
        int wrongPlacementCount = greenTable.WrongPlacement + redTable.WrongPlacement;

        if (wrongPlacementCount > failChance) {
            Debug.Log("YOU LOSE");
            OnLoseGame?.Invoke();
            return;
        }

        int totalPlacedCount;

        totalPlacedCount = greenTable.CorrectPlacement + redTable.CorrectPlacement + wrongPlacementCount;
        
        if (_totalPlaceableCount == totalPlacedCount)
        {
            Debug.Log("YOU WIN");
            OnWinGame?.Invoke();
        }
    }
}
