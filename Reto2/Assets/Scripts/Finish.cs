using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider Collision)
    {
        // Verificar si el objeto que toc� la bandera tiene el tag "Player"
        if (Collision.CompareTag("Player"))
        {
            // Obtener el �ndice del siguiente nivel
            int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Cargar el siguiente nivel
            if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextLevelIndex);
            }
            else
            {
                // Si ya no hay m�s niveles, puedes mostrar un mensaje o hacer otra acci�n
                Debug.Log("�Has completado todos los niveles!");
            }
        }
    }
}