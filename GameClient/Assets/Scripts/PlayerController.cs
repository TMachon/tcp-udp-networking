using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -9.81f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;

    private float yVelocity = 0;
    private bool movementRegistered;

    private void Start()
    {
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;
        moveSpeed *= Time.fixedDeltaTime;
        jumpSpeed *= Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        movementRegistered = false;
        Vector2 _inputDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            movementRegistered = true;
            _inputDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            movementRegistered = true;
            _inputDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementRegistered = true;
            _inputDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementRegistered = true;
            _inputDirection.x += 1;
        }

        Vector3 _moveDirection = transform.right * _inputDirection.x + transform.forward * _inputDirection.y;
        _moveDirection *= moveSpeed;

        if (controller.isGrounded)
        {
            yVelocity = 0f;
            if (Input.GetKey(KeyCode.Space))
            {
                movementRegistered = true;
                yVelocity = jumpSpeed;
            }
        }
        yVelocity += gravity;

        _moveDirection.y = yVelocity;
        controller.Move(_moveDirection);

        if (movementRegistered) 
        { 
            SendInputToServer();
        }
    }

    private void SendInputToServer()
    {
        ClientSend.PlayerMovement(this.transform.position, this.transform.rotation);
    }
}
