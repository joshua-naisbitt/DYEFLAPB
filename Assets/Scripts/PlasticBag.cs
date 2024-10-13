using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlasticBag : MonoBehaviour
{
    GameObject gameManagerObj;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObj = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is the Goal tilemap
        if (other.CompareTag("Goal"))
        {
            gameManager.GameIsActive = false;
            gameManager.finalTime = gameManager.timeElapsed;
            gameManager.timerText.text = "";
            gameManager.DisplayFinalTime(gameManager.finalTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player entered the Goal trigger!");
    }
}
