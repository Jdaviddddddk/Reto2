using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    public Slider fillSlider;
    public TextMeshProUGUI messageText; // Reference to the TextMeshProUGUI component
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        messageText.gameObject.SetActive(false); // Hide the message text at start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            if (fillSlider.value >= fillSlider.maxValue)
            {
                finishSound.Play();
                levelCompleted = true;
                Invoke("CompleteLevel", 1f);
            }
            else
            {
                messageText.gameObject.SetActive(true); // Show the message text
                Invoke("HideMessage", 5f); // Hide the message after a delay
            }
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }
}