using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    TextMeshPro _scoreText;
    ItemPlaceContainer _containerToTrack;

    private void Awake() {
        _containerToTrack = GetComponentInParent<ItemPlaceContainer>();
        _scoreText = GetComponent<TextMeshPro>();
    }

    private void OnEnable() {
        _containerToTrack.OnPlacedCorrect += UpdateScore;
    }

    private void OnDisable() {
        _containerToTrack.OnPlacedCorrect -= UpdateScore;
    }

    void UpdateScore() {
        _scoreText.text = $"{_containerToTrack.CorrectPlacement}/5";
    }
}