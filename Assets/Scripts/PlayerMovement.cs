using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f;   // How fast the player moves
    public Camera arenaCamera;

    private InputActionAsset inputActionAsset;
    private InputActionMap player;
    private InputAction move;

    private Rigidbody rigidBody;                        // Reference to the player's Rigidbody 
    private Vector3 forceDirection = Vector3.zero;      // the force that will be applied to the rb

    private void Awake()
    {
        // Get the Rigidbody component on the player
        rigidBody = GetComponent<Rigidbody>();

        inputActionAsset = this.GetComponent<PlayerInput>().actions;
        player = inputActionAsset.FindActionMap("Player");
    }

    private void OnEnable()
    {
        move = player.FindAction("Move");
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 playerMovement = move.ReadValue<Vector2>();

        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(arenaCamera) * moveSpeed;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(arenaCamera) * moveSpeed;

        rigidBody.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;
    }

    private Vector3 GetCameraRight(Camera arenaCamera)
    {
        Vector3 right = arenaCamera.transform.right;
        right.y = 0f;
        return right.normalized;
    }

    private Vector3 GetCameraForward(Camera arenaCamera)
    {
        Vector3 forward = arenaCamera.transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }
}
