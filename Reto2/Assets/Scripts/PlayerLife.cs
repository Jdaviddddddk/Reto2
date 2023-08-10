using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int remainingLives = 3; // Number of remaining lives
    public GameObject heartContainer; // Reference to the heart container

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            LoseLife();
        }
    }

    private void LoseLife()
    {
        remainingLives--;

        if (remainingLives > 0)
        {
            heartContainer.transform.GetChild(remainingLives).gameObject.SetActive(false);

            anim.SetTrigger("death1");
            StartCoroutine(ResetPositionAfterAnimation());
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator ResetPositionAfterAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        rb.velocity = Vector2.zero;
        rb.position = new Vector2(-8.7f, -2.48f);
    }

    private void RestartLevel()
    {
        if (remainingLives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}