using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string nivel1, nivel2, nivel3;

    public void NewGame()
    {
        SceneManager.LoadScene(nivel1);
    }

    public void Quit()
    {
        Debug.Log("Se ha salido del videojuego.");
        Application.Quit();
    }
    public void Nivel1()
    {
        SceneManager.LoadScene(nivel1);
    }
}
