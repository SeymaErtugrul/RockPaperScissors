using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatMover : MonoBehaviour
{
    public float moveSpeed;
    private PlayerActionControls playerActionControls;
    private Vector2 movementInput;
    private Rigidbody rb;
    CatAnimator catAnimator;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerActionControls = new PlayerActionControls();
        catAnimator = GetComponent<CatAnimator>();
    }
    private void OnEnable()
    {
        playerActionControls.Move.Enable();
        playerActionControls.Move.Moving.performed += OnMove;
        playerActionControls.Move.Moving.canceled += OnMove;
    }

    private void OnDisable()
    {
        playerActionControls.Move.Moving.performed -= OnMove;
        playerActionControls.Move.Moving.canceled -= OnMove;
        playerActionControls.Move.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, toRotation, Time.fixedDeltaTime * 10f)); // 10f: dönüş hızı


        if (moveDirection.magnitude > 0.1f)
        {
            catAnimator.SetIsMoving(true);
        }

        else
        {
            catAnimator.SetIsMoving(false);
        }
    }
}
