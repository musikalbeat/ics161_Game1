// For managing the UI in the playable stages

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectManager : MonoBehaviour
{
    public TMP_Text starText;
    public int starCount;
    public int collected;
    public GameObject homeButton;

    void Start() {
        starCount = 3;
        starText.text = "Star: " + collected.ToString() + "/" + starCount;
    }

    public void Collect() {
        collected += 1;
        starText.text = "Star: " + collected.ToString() + "/" + starCount;
    }

    public void returnHome() {
        Debug.Log("Returning to title...");
        SceneManager.LoadScene(0);
    }
}
