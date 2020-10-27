using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TMP_Text starText;
    int starCount;
    int collected;

    void Start() {
        starCount = 3;
        starText.text = "Star: " + collected.ToString() + "/" + starCount;
    }

    public void Collect() {
        collected += 1;
        starText.text = "Star: " + collected.ToString() + "/" + starCount;
    }
}
