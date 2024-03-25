using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action OnWinGame;
    public event Action OnLoseGame;


    void OnEnable() {
        
    }

    void OnDisable() {
            
    }

    private void Awake() {
        InitializeSingleton();
    }


    void InitializeSingleton() {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    bool CheckIfGameFinished() {
        throw new NotImplementedException();
    }
}
