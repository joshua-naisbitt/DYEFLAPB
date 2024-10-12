using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
public TextMeshProUGUI timerText; // Reference to the TextMeshPro text
    private float timeElapsed = 0f; // To keep track of the elapsed time

    void Update()
    {
        // Update the elapsed time by adding the time passed since the last frame
        timeElapsed += Time.deltaTime;

        // Display the updated time
        DisplayTime(timeElapsed);
    }

    void DisplayTime(float timeToDisplay)
    {
        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = timeToDisplay % 60;

        // Format and display the time in MM:SS
        timerText.text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
    }
}
