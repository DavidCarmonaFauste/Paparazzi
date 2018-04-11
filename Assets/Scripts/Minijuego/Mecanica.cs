using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica : MonoBehaviour {
    int colisiones = 0;
    bool dentro;
    public int fotos = 0;
    //sonido
    AudioSource fuenteAudio;


    private void Start()
    {
        //sonido
        fuenteAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D other)
	{
        if (other.tag != "topeH" && other.tag != "topeV")
        {
            colisiones++;
            dentro = true;
		}
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "topeH" && other.tag != "topeV")
        {
            colisiones--;
            dentro = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "topeH" && other.tag != "topeV")
        {
            
            dentro = true;
        }
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //sonido
            fuenteAudio.Play();

            if (dentro)
                fotos = fotos + colisiones;
        }
    }

}