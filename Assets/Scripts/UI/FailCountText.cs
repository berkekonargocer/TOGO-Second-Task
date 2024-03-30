using TMPro;
using UnityEngine;

public class FailCountText : MonoBehaviour
{
    TextMeshProUGUI _failCountText;

    [SerializeField] ItemPlaceContainer[] _containers;

    private void Awake() {
        _failCountText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
        for (int i = 0; i < _containers.Length; i++)
        {
            _containers[i].OnPlacedWrong += UpdateText;
        }
    }

    private void OnDisable() {
        for (int i = 0; i < _containers.Length; i++)
        {
            _containers[i].OnPlacedWrong -= UpdateText;
        }
    }

    void UpdateText() {
        int wrongPlacements = 0;

        for (int i = 0; i < _containers.Length; i++)
        {
            wrongPlacements += _containers[i].WrongPlacement;
        }

        _failCountText.text = $"Fail Count: {wrongPlacements}";
    }
}