using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    int actual = -1;
    string tutorial; //¿Qué tutorial es este? "inicial" o "camaras"
    void Start()
    {
        if (this.transform.childCount > 1)
        {
            tutorial = "inicial";
        }
        else
        {
            tutorial = "camaras";
        }

        if (!GameManager.instance.MinijuegoTerminado())
        {
            Invoke("TutoInicial", 0.75f);

        }
    }

    void Update()
    {
        if (!GameManager.instance.CheckTutorial())
        {
            if (tutorial == "inicial") //Si se trata del tutorial inicial
            {
                if (Input.GetKeyDown(KeyCode.Space) && actual != 2 && actual != -1)
                {
                    this.transform.GetChild(actual).gameObject.SetActive(false);
                    actual++;
                    this.transform.GetChild(actual).gameObject.SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.Space) && actual == 2 && actual != -1)
                {
                    this.transform.GetChild(actual).gameObject.SetActive(false);
                    GameManager.instance.SetPause(false);
                    GameManager.instance.SetAllowPausa(true); //permite pausar
                    Time.timeScale = 1f;
                }
            }
            else //Si es el mensaje de la cámara
            {
                GameManager.instance.SetAllowPausa(false); //no permite pausar
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.instance.VistoTutorial();
                    GameManager.instance.SetAllowPausa(true); //permite pausar
                    this.transform.GetChild(actual).gameObject.SetActive(false);
                    GameManager.instance.SetPause(false);
                    Destroy(this.transform.GetChild(actual).gameObject);
                    Time.timeScale = 1f;
                }
            }
        }
    }

    void TutoInicial()
    {
        GameManager.instance.SetPause(true);
        Time.timeScale = 0f;
        GameManager.instance.SetAllowPausa(false); //no permite pausar
        actual = 0;
        this.transform.GetChild(actual).gameObject.SetActive(true); //Activar la primera imagen al empezar el nivel

        
    }
}
