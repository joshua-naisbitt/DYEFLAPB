using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float maxForceStrength = 50f; // Maximum strength of the fan force
    public float minDistance = 0f; // Minimum distance at which the fan starts applying force
    public float maxDistance = 10f; // Maximum distance beyond which the fan stops applying force
    private Vector2 direction; // Direction of the fan force
    public KeyCode activationKey = KeyCode.Space; // Key to activate the fan
    public bool OnByDefault = false; // Whether the fan is by default on or off 

    private GameObject player; // Reference to the player object

    void Start()
    {
        // Find the player by tag (assuming the player has the "Player" tag)
        player = GameObject.FindGameObjectWithTag("Player");
        direction = transform.right;
        Debug.Log(transform.right);
    }
    void FixedUpdate(){
        if (Input.GetKey(activationKey) != OnByDefault){
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // Only apply force if the activation key is pressed
        if (Input.GetKey(activationKey) != OnByDefault)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            // Check if the object has a Rigidbody2D component
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null && player != null)
            {
                // Calculate distance between the player and the fan
                float distance = Vector2.Distance(transform.position, player.transform.position);

                // If within range, calculate force proportional to the distance
                if (distance >= minDistance && distance <= maxDistance)
                {
                    // Calculate the proportional force (inverse relationship)
                    float distanceFactor = 1 - ((distance - minDistance) / (maxDistance - minDistance));
                    float force = maxForceStrength * distanceFactor;

                    // Apply the force in the fan's direction
                    rb.AddForce(direction.normalized * force);
                    rb.AddForce(Vector2.up * force * 0.2f);
                }
            }
        }
        else {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    // (Optional) Visualize the range of the fan in the Scene view
    private void OnDrawGizmosSelected()
    {
        // Draw a sphere to indicate the max range of the fan
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDistance);

        // Draw a sphere to indicate the min range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}