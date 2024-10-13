using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI timerText; // Reference to the TextMeshPro text
    public TextMeshProUGUI finalText; // Reference to the TextMeshPro text
    public GameObject Dim; //Dim Screen Panel
    public Vector2 startPosition; // Where the text starts off-screen
    public Vector2 endPosition;   // Where the text will slide in
    public string nextSceneName; //Next level after current
     public float duration = 0.5f; // Time it takes for the text to slide in
    [HideInInspector] public float timeElapsed = 0f; // To keep track of the elapsed time
    [HideInInspector] public float finalTime = 0f;
    [HideInInspector] public bool GameIsActive;
    private RectTransform textRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        textRectTransform = finalText.rectTransform;
        GameIsActive = true;
        Dim.SetActive(false);
        startPosition = new Vector2(0f, 1000f);
        endPosition = new Vector2(0f, 0f);
        textRectTransform.anchoredPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the elapsed time by adding the time passed since the last frame
        timeElapsed += Time.deltaTime;
        // Display the updated time
        if (GameIsActive){
            DisplayTime(timeElapsed);
            Reset();
        }
        NextLevel();
    }
    void DisplayTime(float timeToDisplay)
    {
        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = timeToDisplay % 60;

        // Format and display the time in MM:SS
        timerText.text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
    }
    public void DisplayFinalTime(float timeToDisplay)
    {
        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = timeToDisplay % 60;
        // Format and display the time in MM:SS
        timerText.text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
        finalText.text = string.Format("Time: {0:00}:{1:00.00}", minutes, seconds);
        
        Dim.SetActive(true);
        StartCoroutine(SlideIn());
    }

    IEnumerator SlideIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Lerp the position based on the time passed
            textRectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set
        textRectTransform.anchoredPosition = endPosition;
    }
    void Reset(){
        //reset
        if (GameIsActive){
            if (Input.GetKeyDown(KeyCode.R)){
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }
    void NextLevel(){
        //reset
        if (!GameIsActive){
            if (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
