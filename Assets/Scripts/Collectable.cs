using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject cm;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            cm.GetComponent<CanvasManager>().Collect();
            Destroy(this.gameObject);
        }
    }
}
