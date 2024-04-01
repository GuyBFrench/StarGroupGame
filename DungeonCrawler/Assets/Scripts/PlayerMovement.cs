using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f; // Movement speed
    public float gravity = 20.0f; // Gravity force
    private CharacterController controller; // Reference to the CharacterController component

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to this GameObject
    }

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D keys or left/right arrow keys
        float verticalInput = Input.GetAxis("Vertical"); // W/S keys or up/down arrow keys

        // Calculate movement direction based on input
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement = transform.TransformDirection(movement); // Convert local space to world space

        // Apply movement speed
        movement *= speed;

        // Apply gravity
        movement.y -= gravity * Time.deltaTime;

        // Move the player
        controller.Move(movement * Time.deltaTime);
    }
}