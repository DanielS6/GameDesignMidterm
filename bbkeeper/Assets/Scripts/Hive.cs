using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hive : MonoBehaviour {

    // User display
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Number of collected items so far
    private int collectedCount;

    // Start is called before the first frame update
    void Start() {
        collectedCount = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText() {
        countText.text = "Count: " + collectedCount.ToString();
        if (collectedCount >= 16) {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerController bee = other.GetComponent<PlayerController>();
            collectedCount += bee.inventoryCount;
            bee.inventoryCount = 0;
            SetCountText();
        }
    }
}
