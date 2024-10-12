using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is the Tilemap
        if (other.CompareTag("Goal"))
        {
            Debug.Log("Player entered the Tilemap trigger!");
            // Trigger your interaction here
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
