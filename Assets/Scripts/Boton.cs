using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour {
    //sonido
    AudioSource fuenteAudio;
    public GameObject camara;
    bool dentro, activado;

    private void Start()
    {
        //sonido
        fuenteAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (dentro && GameObject.FindWithTag("Player").GetComponent<Controller>().CompruebaE() && !activado)
        {
            DesactivaBoton();
            activado = true;
            //sonido
            fuenteAudio.Play();
        }
        else if (dentro && GameObject.FindWithTag("Player").GetComponent<Controller>().CompruebaE() && activado)
        {
            ActivaBoton();
            activado = false;
            //sonido
            fuenteAudio.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            dentro = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            dentro = false;
    }

    void DesactivaBoton()
    {
        camara.transform.GetChild(0).gameObject.SetActive(false);
    }
    void ActivaBoton()
    {
        camara.transform.GetChild(0).gameObject.SetActive(true);
    }
}
