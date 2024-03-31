using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class StickMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float rotateSpeed = 5.0f;

    [SerializeField] string moveAnimationParameter = "isMoving";

    Vector2 _moveDirection;

    Rigidbody _objectRigidbody;
    PlayerInput _playerInput;
    Animator _animator;


    void OnEnable() {
        GameManager.Instance.OnWinGame += StopMovement;
        GameManager.Instance.OnLoseGame += StopMovement;

    }

    void OnDisable() {
        GameManager.Instance.OnWinGame -= StopMovement;
        GameManager.Instance.OnLoseGame -= StopMovement;
    }

    void Awake() {
        _objectRigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        ApplyMovement();
        ApplyAnimation();
        Rotate();
    }

    Vector3 GetMovementDirection() {
        _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(_moveDirection.x, 0, _moveDirection.y) * movementSpeed * Time.fixedDeltaTime;
        return moveDirection;
    }

    void ApplyMovement() {
        _objectRigidbody.MovePosition(_objectRigidbody.position + GetMovementDirection());
    }

    void ApplyAnimation() {
        _animator.SetBool(moveAnimationParameter, GetMovementDirection() != Vector3.zero);
    }

    void Rotate() {
        Vector3 targetDirection = Vector3.RotateTowards(transform.forward, GetMovementDirection(), rotateSpeed * Time.fixedDeltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    void StopMovement() {
        _objectRigidbody.velocity = Vector3.zero;
        enabled = false;
    }
}