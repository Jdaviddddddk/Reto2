using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItems : MonoBehaviour
{
    public AudioSource Collected;
    private int bananas = 0;

 
    [SerializeField] private TextMeshProUGUI CherriesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bananas"))
        {
            Collected.Play();
            Destroy(collision.gameObject);
            bananas++;
            CherriesText.text = "" + bananas;
        }
    }
}
