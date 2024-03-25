using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class StickMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5.0f;

    Vector2 _moveDirection;

    PlayerInput _playerInput;
    Rigidbody _objectRigidbody;


    void Awake() {
        _objectRigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate() {
        ApplyMovement();
    }

    Vector3 GetMovementDirection() {
        _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();

        Vector3 moveDirection;

        moveDirection = new Vector3(_moveDirection.x, 0, _moveDirection.y) * movementSpeed * Time.fixedDeltaTime;
        return moveDirection;
    }

    void ApplyMovement() {
        _objectRigidbody.MovePosition(_objectRigidbody.position + GetMovementDirection());
    }

    void StopMovement() {
        _objectRigidbody.velocity = Vector3.zero;
        enabled = false;
    }
}
