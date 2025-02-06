using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f;       // How fast the player is able to move
    public float blowStrength = 10f;    // How powerful the nightmares will be blown back
    public float actionTimer = 1f;      // How often the player can suck/blow
    public Camera arenaCamera;          // The main camera, so movement will be based on its position if it moves
    public MatchData matchData;         // Used to send players score to the match data

    private Rigidbody rigidBody;                        // Reference to the player's Rigidbody 
    private Vector3 forceDirection = Vector3.zero;      // The force that will be applied to the rb
    private float actionTimeSinceActivated = 0;         // Time since Blow/Suck was last activated

    // Input Action variables
    private InputActionAsset inputActionAsset;
    private InputActionMap player;
    private InputAction move;

    private void Awake()
    {
        // Get the Rigidbody component on the player
        rigidBody = GetComponent<Rigidbody>();

        // Set up the Input Actions for this player
        inputActionAsset = this.GetComponent<PlayerInput>().actions;
        player = inputActionAsset.FindActionMap("Player");
    }

    // Enable this player's controls
    private void OnEnable()
    {
        move = player.FindAction("Move");
        player.FindAction("Suck").started += DoSuck;
        player.FindAction("Blow").started += DoBlow;
        player.Enable();
    }

    // Disable this player's controls
    private void OnDisable()
    {
        player.FindAction("Suck").started -= DoSuck;
        player.FindAction("Blow").started -= DoBlow;
        player.Disable();
    }

    private void Update()
    {
        actionTimeSinceActivated += Time.deltaTime;
    }

    // Updates every fixed framerate frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    // Calculate the movement for the player
    void MovePlayer()
    {
        // Read the player's inputs
        Vector2 playerMovement = move.ReadValue<Vector2>();

        // Calculate the movement based on the camera position
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(arenaCamera) * moveSpeed;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(arenaCamera) * moveSpeed;

        // Add the force to the object
        rigidBody.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;
    }

    // Suck up the nightmares within the zone range
    private void DoSuck(InputAction.CallbackContext context)
    {
        if (actionTimeSinceActivated > actionTimer)
        {
            Collider[] collectibles = Physics.OverlapSphere(transform.position, transform.localScale.x / 2);

            foreach (Collider collectible in collectibles)
            {
                if (collectible.CompareTag("Collectible"))
                {
                    matchData.AddScore();
                    Destroy(collectible.gameObject);
                }
            }

            actionTimeSinceActivated = 0f;
        }

        Debug.Log("Sucked");
    }

    // Push back the nightmares within the zone range
    private void DoBlow(InputAction.CallbackContext context)
    {
        if (actionTimeSinceActivated > actionTimer)
        {
            Collider[] collectibles = Physics.OverlapSphere(transform.position, transform.localScale.x / 2);

            foreach (Collider collectible in collectibles)
            {
                if (collectible.CompareTag("Collectible"))
                {
                    Rigidbody rb = collectible.GetComponent<Rigidbody>();
                    Vector3 blowDirection = (collectible.transform.position - transform.position).normalized;

                    Vector3 blowForce = blowDirection * blowStrength;

                    rb.AddForce(blowForce);
                }
            }

            actionTimeSinceActivated = 0f;
        }

        Debug.Log("Blown");
    }

    // Grab the camera's right parameters
    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 right = camera.transform.right;
        right.y = 0f;
        return right.normalized;
    }

    // Grab the camera's forward parameters
    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forward = camera.transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }
}
