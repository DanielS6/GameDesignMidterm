using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

    // Movement
    public float speed = 0;
    private float movementX;
    private float movementY;

    // User display
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Actual moving object
    private Rigidbody playerRigidBody;

    // Number of collected items so far
    private int count;

    // Start is called before the first frame update
    void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        // Currently pressing a move key, rather than letting go
        if (movementX != 0 || movementY != 0) {
            updateLookDirection(movementX, movementY);
        }
    }

    private void updateLookDirection(float lookX, float lookY) {
        // For each direction, the looX, lookY, and desired rotation are:
        // Up arrow: 0, 1, 90
        // down arrow: 0, -1, -90
        // right arrow: 1, 0, 180
        // left arrow: -1, 0, 0
        float yRotation;
        if (lookX == 0) {
            // up or down
            yRotation = (lookY == 1 ? 90.0f : -90.0f);
        } else {
            // left or right
            yRotation = (lookX == 1 ? 180.0f : 0.0f);
        }
        // reset, so that the rotation is relative to starting 0/0/0 instead
        // of relative to the current orientation
        transform.localRotation = Quaternion.identity;
        transform.Rotate(0.0f, yRotation, 0.0f, Space.World);
    }

    void FixedUpdate() {
        // Move the player according to current direction and speed
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        playerRigidBody.AddForce(movement * speed);
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 16) {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Nectar")) {
            Destroy(other.gameObject);
            count += 1;
            SetCountText();
        }
    }
}
