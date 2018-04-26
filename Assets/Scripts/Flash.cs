using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    //sonido
    public AudioClip flashSound;
    public AudioClip cameraSound;
    AudioSource fuenteAudio;

    private GameObject Area;
    private GameObject ConoFlash;
    private GameObject ConoFoto;
    private Rigidbody2D rbConoFlash;
    private Rigidbody2D rbConoFoto;


    void Start()
    {
        //sonido
        fuenteAudio = GetComponent<AudioSource>();

        Area = this.transform.GetChild(0).gameObject;
        ConoFlash = this.transform.GetChild(1).gameObject;
        ConoFoto = this.transform.GetChild(2).gameObject;
        rbConoFlash = ConoFlash.GetComponent<Rigidbody2D>();
        rbConoFoto = ConoFoto.GetComponent<Rigidbody2D>();

        Invisible();
    }

    void Update()
    {
        if (!MenuPausa.GameIsPaused) // Si el juego no está en PAUSA
        {
			if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.instance.bombillas > 0)
            {
                VisibleFlash();

            }

            else if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.carretes > 0)
            {
                VisibleFoto();

            }

            if (  Input.GetKeyUp(KeyCode.Mouse1)  && GameManager.instance.carretes > 0)
            {

                Invisible();
                if (ConoFoto.GetComponent<Raycast>().LeVeo() && ConoFoto.GetComponent<Raycast>().Frente() && ConoFoto.GetComponent<Raycast>().FotoAQuien().CompareTag("Famoso"))//Si esta de frente y dentro llama a stun
					GameManager.instance.SumaPuntos((2500/2), "ptosFotoOp");
                else if (ConoFoto.GetComponent<Raycast>().LeVeo() && !ConoFoto.GetComponent<Raycast>().Frente() && ConoFoto.GetComponent<Raycast>().FotoAQuien().CompareTag("Famoso"))
                    GameManager.instance.SumaPuntos(750/2, "ptosFotoOp");

                GameManager.instance.carretes--;
                //sonido
                fuenteAudio.clip = cameraSound;
                fuenteAudio.volume = 0.5f;
                fuenteAudio.Play();

            }
			if(Input.GetKeyUp(KeyCode.Mouse0) && GameManager.instance.bombillas > 0)
            {
                Invisible();
                if (ConoFlash.GetComponent<Raycast>().LeVeo() && ConoFlash.GetComponent<Raycast>().Frente())//Si esta de frente y dentro llama a stunn
                    ConoFlash.GetComponent<Raycast>().Stunn();

				GameManager.instance.bombillas--;
                //sonido
                fuenteAudio.clip = flashSound;
                fuenteAudio.volume = 0.25f;
                fuenteAudio.Play();
            }
        }

    }

    void Invisible()
    {
        Area.SetActive(false);
        ConoFlash.SetActive(false);
        ConoFoto.SetActive(false);
        rbConoFlash.Sleep();
        rbConoFoto.Sleep();
    }

    void VisibleFoto()
    {
        Area.SetActive(true);
        ConoFoto.SetActive(true);
        rbConoFoto.WakeUp();
    }

    void VisibleFlash()
    {
        Area.SetActive(true);
        ConoFlash.SetActive(true);
        rbConoFlash.WakeUp();
    }
}
