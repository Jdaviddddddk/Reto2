using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCanvas : MonoBehaviour
{

    public GameObject Panel;
    bool PanelActivo = false;
    public void Niveles(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }


    public void Quit()
    {
        Application.Quit();
    }

   


    public void PanelPausa()
    {
        PanelActivo = !PanelActivo;
        Panel.SetActive(PanelActivo);

    }
}
