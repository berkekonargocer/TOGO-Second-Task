using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    ItemPlaceContainer _containerToTrack;

    private void Awake() {
        _containerToTrack = GetComponentInParent<ItemPlaceContainer>();
    }

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }

    void UpdateScore() {

    }
}
