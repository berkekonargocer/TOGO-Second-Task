using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform objectToLookAt;

    void Update()
    {
        transform.LookAt(objectToLookAt);
    }
}