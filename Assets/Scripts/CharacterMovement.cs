using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private const float gravityValue = -9.821f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float fasterPlayerSpeed = 5.0f;
    private float jumpHeight = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        ResetPlayerVelocityY();
        Jump();
        ChangeWalkSpeed();
        Vector3 move = Move();
        ApplyGravity();
        RotateIntoMoveDirection(move);
        
    }

    private Vector3 Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move((move * playerSpeed + playerVelocity) * Time.deltaTime);
        return move;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }

    private void ResetPlayerVelocityY()
    {
        if (groundedPlayer && playerVelocity.y< 0)
        {
            playerVelocity.y = 0f;
        }
    }

    private void ApplyGravity()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
    }

    private void RotateIntoMoveDirection(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
        }
    }
    private void ChangeWalkSpeed()
    {
        if (Input.GetButton("LeftShift"))
        {
            playerSpeed = fasterPlayerSpeed;
        }
        else
        {
            playerSpeed = 2.0f;
        }
    }
}
