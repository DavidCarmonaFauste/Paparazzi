using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    int actual = -1;
    string tutorial; //¿Qué tutorial es este? "inicial" o "camaras"
    void Awake()
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
            GameManager.instance.SetPause(true);
            Time.timeScale = 0f;
            actual = 0;
            this.transform.GetChild(actual).gameObject.SetActive(true); //Activar la primera imagen al empezar el nivel
        }
    }

    void Update()
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
                Time.timeScale = 1f;
            }
        }
        else //Si es el mensaje de la cámara
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.transform.GetChild(actual).gameObject.SetActive(false);
                GameManager.instance.SetPause(false);
                Destroy(this.transform.GetChild(actual).gameObject);
                Time.timeScale = 1f;
            }
        }

    }
}
