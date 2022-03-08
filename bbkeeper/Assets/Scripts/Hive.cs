using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hive : MonoBehaviour {

    // User display
    public TextMeshProUGUI countText;

    // Number of collected items so far
    public static int score = 0;

    // Start is called before the first frame update
    void Start() {
        score = 0;

        SetCountText();
    }

    void SetCountText() {
        countText.text = "Total Nectar: " + score.ToString();

        // changed end condition to be timer instead of nectar amount
        // if (score >= 16) {
        //     SceneManager.LoadScene("VictoryScene");
        // }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerController bee = other.GetComponent<PlayerController>();
            score += bee.inventoryCount;
            // All nectars carried by the bee are added to the hive
            bee.inventoryCount = 0;
            // update inventory text
            bee.SetInventoryText();
            // update total count text
            SetCountText();
        }
    }
}
