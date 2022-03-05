using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingController : MonoBehaviour {

    // Event handler
    public void LaunchGameScene() {
        SceneManager.LoadScene("GameScene");
    }

}
