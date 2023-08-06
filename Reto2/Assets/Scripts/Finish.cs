using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider Collision)
    {
        // Verificar si el objeto que tocó la bandera tiene el tag "Player"
        if (Collision.CompareTag("Player"))
        {
            // Obtener el índice del siguiente nivel
            int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Cargar el siguiente nivel
            if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextLevelIndex);
            }
            else
            {
                // Si ya no hay más niveles, puedes mostrar un mensaje o hacer otra acción
                Debug.Log("¡Has completado todos los niveles!");
            }
        }
    }
}