using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento wasd y flechas
        movement = new Vector2(
            Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed ? 1 :
            Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed ? -1 : 0,

            Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed ? 1 :
            Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed ? -1 : 0
        ).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}