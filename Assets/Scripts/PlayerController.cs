using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 movement;
    Rigidbody rigiBody;

    private void Awake()
    {
        rigiBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = rigiBody.position;// получаем текущую позицию
        Vector3 moveDirrection = new Vector3(movement.x, 0f, movement.y);// создаем направление движения
        Vector3 newPosition = currentPosition + moveDirrection * (moveSpeed * Time.fixedDeltaTime);// вычесляем новую позицию

        rigiBody.MovePosition(newPosition);// двигаем Rigibody
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

    }
}
