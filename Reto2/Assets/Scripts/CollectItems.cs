using UnityEngine;
using UnityEngine.UI;

public class CollectItems : MonoBehaviour
{
    public AudioSource Collected;
    public Slider bananasSlider; // Reference to the Slider component
    private int bananas = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bananas"))
        {
            Collected.Play();
            Destroy(collision.gameObject);
            bananas++;

            // Update the slider value based on the bananas collected
            bananasSlider.value = bananas;
        }
    }
}