using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject virtualCam;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is the Tilemap
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
            // Trigger your interaction here
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object is the Tilemap
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
            // Trigger your interaction here
        }
    }
}
