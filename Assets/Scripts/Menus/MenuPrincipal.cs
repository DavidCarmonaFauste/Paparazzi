using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public string nivel1, nivel2, nivel3;

    public void NewGame()
    {
		GameManager.instance.InicializaObjetos ();
        GameManager.instance.Nivel1();
        GameManager.instance.NuevaPartida();
    }

    public void Quit()
    {
        Debug.Log("Se ha salido del videojuego.");
        Application.Quit();
    }
    public void Nivel1()
    {
        GameManager.instance.InicializaObjetos();
        GameManager.instance.Nivel1();
    }
        public void Desactiva()
        {
        gameObject.SetActive(false);
        }
    public void Activa()
    {
        gameObject.SetActive(true);
        }
}
