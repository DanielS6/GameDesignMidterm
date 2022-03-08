using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    // Prefab of nectar to create, for now just a placeholder
    public GameObject nectarPrefab;

    // Timing the random nectar creation, for now a nectar is created every
    // 5 seconds
    // public float nectarMaxDelay = 2.0f;
    private float nectarTimer;

    // Directions around the flower to create new nectar, multiplied by a
    // random magnitute
    private Vector3[] creationDirections = new Vector3[8];

    // Initialize creationPoints on startup
    void Start() {
        creationDirections[0] = new Vector3(0.0f, 0.0f, 1.0f);
        creationDirections[1] = new Vector3(1.0f, 0.0f, 1.0f);
        creationDirections[2] = new Vector3(1.0f, 0.0f, 0.0f);
        creationDirections[3] = new Vector3(1.0f, 0.0f, -1.0f);
        creationDirections[4] = new Vector3(0.0f, 0.0f, -1.0f);
        creationDirections[5] = new Vector3(-1.0f, 0.0f, -1.0f);
        creationDirections[6] = new Vector3(-1.0f, 0.0f, 0.0f);
        creationDirections[7] = new Vector3(-1.0f, 0.0f, 1.0f);
    }

    void FixedUpdate() {
        // float timeToCreate = Random.Range(0, nectarMaxDelay);
        nectarTimer += 0.01f;
        // for now a nectar is created every 5 seconds
        if (nectarTimer > 5.0f) {
            createNewNectar();
            nectarTimer = 0f;
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
