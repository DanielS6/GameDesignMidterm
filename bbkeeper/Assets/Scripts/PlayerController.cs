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
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }
}
