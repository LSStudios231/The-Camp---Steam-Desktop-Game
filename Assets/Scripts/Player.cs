using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 5f;

    public Camera playerCamera;

    private Vector3 moveDirection;

    private float rotationX = 0f;
    private float rotationY = 0f;
    public float detectionRadius = 30f;

    public GameObject player;

    public AudioSource footstepsSounds;
    void Start()
    {
        Cursor.visible = false;

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        // Get the forward direction of the camera
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0; // Set the y value to 0 to prevent movement in the y direction

        // Get the right direction of the camera
        Vector3 cameraRight = playerCamera.transform.right;

        // Get the user input for movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Calculate the move direction based on camera orientation and user input
        moveDirection = (horizontal * cameraRight + vertical * cameraForward).normalized;

        // Get the mouse input for rotation
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity;

        // Rotate the player based on mouse input
        rotationX += mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp the rotation to prevent flipping

        transform.localRotation = Quaternion.Euler(-rotationX, rotationY, 0f);

        // Move the player based on the move direction and move speed
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            footstepsSounds.enabled = true;
        }
        else
        {
            footstepsSounds.enabled = false;
        }
    }

}
