using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taser : MonoBehaviour {

    bool puedoDisparar = true;




    GameObject vision, taser, tasersprite;
     
    private void Start()
    {
        
        taser = transform.GetChild(4).gameObject;
        tasersprite = taser.transform.GetChild(0).gameObject;
    }
    void Update()
    {
        //Si esta dentro de la vision y ha pasado el coldown puede disparar
        if (taser.GetComponent<Detect>().Dentro() && puedoDisparar)
        {
            puedoDisparar = false;
            gameObject.GetComponent<Patrol>().Spray();
            Invoke("EfectuaDisparo", 0.5f);

        }

    }



    void EfectuaDisparo()
    {
        if (taser.GetComponent<Detect>().LeVeo())
        {
            
            GameObject.FindWithTag("Player").GetComponent<Controller>().Stuned();
            
        }
        tasersprite.SetActive(true);
        Invoke("Desactiva", 0.2f);
        Invoke("PuedesDisparar", 4);//4 segundos para que pueda volver a disparar
    }

    void PuedesDisparar()
    {
        puedoDisparar = true;
    }
    void Desactiva()
    {
        tasersprite.SetActive(false);
    }
}
