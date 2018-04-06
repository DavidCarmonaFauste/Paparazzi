using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    private GameObject Area;
    private GameObject ConoFlash;
    private GameObject ConoFoto;
    private Rigidbody2D rbConoFlash;
    private Rigidbody2D rbConoFoto;


    void Start()
    {

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
            if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.instance.carretes > 0)
            {
                VisibleFlash();
                GameManager.instance.carretes--;

            }

            else if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.camaras > 0)
            {
                VisibleFoto();
                GameManager.instance.camaras--;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1) && GameManager.instance.carretes > 0 && GameManager.instance.camaras > 0)
            {
                Invisible();
                if (ConoFlash.GetComponent<Raycast>().LeVeo() && ConoFlash.GetComponent<Raycast>().Frente())
                    ConoFlash.GetComponent<Raycast>().Stunn();
                    
                


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
