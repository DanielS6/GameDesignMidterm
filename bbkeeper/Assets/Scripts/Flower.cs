using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    // Prefab of nectar to create
    public GameObject nectarPrefab;

    // Timing the random nectar creation, somewhere between 2 and 5 seconds
    // after which the nectar should be created
    private float nectarCreationDelay;
    // Timing the random nectar creation, time since last created
    private float nectarTimer;

    // Directions around the flower to create new nectar, multiplied by a
    // random magnitute
    private Vector3[] creationDirections = new Vector3[8];

    void Start() {
        // Initialize creationDirections
        creationDirections[0] = new Vector3(0.0f, 0.0f, 1.0f);
        creationDirections[1] = new Vector3(1.0f, 0.0f, 1.0f);
        creationDirections[2] = new Vector3(1.0f, 0.0f, 0.0f);
        creationDirections[3] = new Vector3(1.0f, 0.0f, -1.0f);
        creationDirections[4] = new Vector3(0.0f, 0.0f, -1.0f);
        creationDirections[5] = new Vector3(-1.0f, 0.0f, -1.0f);
        creationDirections[6] = new Vector3(-1.0f, 0.0f, 0.0f);
        creationDirections[7] = new Vector3(-1.0f, 0.0f, 1.0f);
        // Created 0 seconds ago, i.e. start timing from now
        nectarTimer = 0.0f;
        // How long before the next nectar is created
        nectarCreationDelay = Random.Range(2.0f, 5.0f);
    }

    void FixedUpdate() {
        nectarTimer += 0.01f;
        // check if its been long enough
        if (nectarTimer > nectarCreationDelay) {
            createNewNectar();
            // Reset timer, randomize new delay
            nectarTimer = 0.0f;
            nectarCreationDelay = Random.Range(2.0f, 5.0f);
        }
    }

    void createNewNectar() {
        // Create a new nectar instance around the current flower
        // Will be in one of the directions around the flower
        int creationDirNum = Random.Range(0, 7);
        Vector3 creationDirection = creationDirections[creationDirNum];
        float creationAmplitude = Random.Range(1.0f, 3.0f);
        // Don't create underground, move to y=.6 always, at this height it
        // collides with the bee
        Vector3 creationPosition = transform.position + (
            creationDirection * creationAmplitude
        );
        creationPosition.y = 0.6f;
        Instantiate(
            nectarPrefab,
            creationPosition,
            Quaternion.identity // no rotation
        );
    }
}
