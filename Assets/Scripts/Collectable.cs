using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public GameObject cm;
    public GameObject info;
    private Scene scene;
    
    private void Start()
    {
        info = GameObject.Find("Info");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && this.gameObject.tag == "collect") {
            cm.GetComponent<CollectManager>().Collect();
            Destroy(this.gameObject);
        }
        
        if (other.tag == "Player" && this.gameObject.tag == "goal") {
            // Update player info: CurrentLevel and Level Selection Screen
            info.GetComponent<PlayerManager>().currentLevel += 1;
            info.GetComponent<PlayerManager>().UpdateLevel( int.Parse(scene.name), cm.GetComponent<CollectManager>().collected );
            
            // Saves data before moving to new stage
            

            // Moves player into next stage
            Debug.Log("Next Scene");
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1, LoadSceneMode.Single);
            
        }
    }
}
