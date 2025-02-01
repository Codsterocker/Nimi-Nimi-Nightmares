using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // How fast the player moves
    private Rigidbody rigidBody;    // Reference to the player's Rigidbody

    void Start()
    {
        // Get the Rigidbody component on the player
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the player
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Apply movement to the Rigidbody
        rigidBody.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }
}
