using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public GameObject cm;
    private Scene scene;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && this.gameObject.tag == "collect") {
            cm.GetComponent<CollectManager>().Collect();
            Destroy(this.gameObject);
        }
        
        if (other.tag == "Player" && this.gameObject.tag == "goal") {
            Debug.Log("Next Scene");
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1, LoadSceneMode.Single);
        }
    }
}
