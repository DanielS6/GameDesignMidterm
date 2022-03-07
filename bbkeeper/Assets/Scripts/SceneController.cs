using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    // Event handler
    public void LaunchGameScene() {
        SceneManager.LoadScene("GameScene");
    }

    public void LaunchEndGame() {
        SceneManager.LoadScene("EndScene");
    }

}
