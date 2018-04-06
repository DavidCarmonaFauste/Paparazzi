using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour {

    public GameObject camara;
    bool dentro, activado;

    private void Update()
    {
        if (dentro && GameObject.FindWithTag("Player").GetComponent<Controller>().CompruebaE() && !activado)
        {
            DesactivaBoton();
            activado = true;
        }
        else if (dentro && GameObject.FindWithTag("Player").GetComponent<Controller>().CompruebaE() && activado)
        {
            ActivaBoton();
            activado = false;
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
