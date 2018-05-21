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
    int multiplicador = 2000;        //multiplicador de la puntuaicón

    public GameObject clickIcon, continueText;    //Guarda el icono de click/continuar
    bool fotoHecha = false; //True si ya ha hecho una foto bien

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
		if(fotoHecha && Input.GetKeyDown(KeyCode.Space))    //Termina el juego si ya ha hecho una foto y pulsa Espacio
        {
            GameManager.instance.Minijuego();
            GameManager.instance.FinMinijuego();
        }

        if (Input.GetMouseButtonDown (0) && puedeFoto && (GameManager.instance.Carretes () > 0 || GameManager.instance.carreteEspecial > 0)) {
			//audio
			fuenteAudio.Play ();

			// El primer carrete que se gasta es el especial
			if (GameManager.instance.carreteEspecial == 1)
				GameManager.instance.carreteEspecial--;
			else
				GameManager.instance.carretes--;
            

			fotos = fotos + colisiones;
			puedeFoto = false;

            if (dentro)
            {
                GameManager.instance.SumaPuntos(multiplicador, "minijuego");
                if (!fotoHecha) PrimeraFotoBien();  //Primera foto hecha
            }

			//Puntuacion();
			Invoke ("PuedeFoto", tiempoFoto);    // Sólo puede echar una foto si han pasado n segundos
		} else if (GameManager.instance.Carretes () == 0 && GameManager.instance.carreteEspecial == 0) 
		{
			GameManager.instance.Minijuego ();
            GameManager.instance.FinMinijuego ();
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

    void PrimeraFotoBien()
    {
        fotoHecha = true;

        //Avisar al jugador de que ya puede continuar
        clickIcon.SetActive(false);
        continueText.SetActive(true);
    }

}