using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica : MonoBehaviour {
    //audio
    AudioSource fuenteAudio;

    public float tiempoFoto;        //retardo entre foto y foto
    public int fotos = 0;           //variable que guarda las fotos "buenas"

    bool puedeFoto = true;          //variable aux para permitir hacer foto
    int colisiones = 0;
    bool dentro;
    int puntuacion = 0;             //variable que guarda la puntuación
    int multiplicador = 100;        //multiplicador de la puntuaicón
   

    private void Start()
    {
        //sonido
        fuenteAudio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D (Collider2D other)
	{
        if (other.tag == "Objetivo")
        {
            colisiones++;
            dentro = true;
		}
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Objetivo")
        {
            colisiones--;
            dentro = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Objetivo")
        {
            
            dentro = true;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && puedeFoto)
        {
            //audio
            fuenteAudio.Play();
            fotos = fotos + colisiones;
            puedeFoto = false;
            Puntuacion();
            Invoke("PuedeFoto", tiempoFoto);    // Sólo puede echar una foto si han pasado n segundos
        }
    }

    void PuedeFoto()
    {
        puedeFoto = true;
    }

    void Puntuacion()
    {
        puntuacion = puntuacion + multiplicador;
    }

}