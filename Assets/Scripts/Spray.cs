using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour {

    bool puedoDisparar = true;

    GameObject vision;
    private void Start()
    {
        vision = transform.GetChild(0).gameObject;
    }
    void Update() {
		//Si esta dentro de la vision y ha pasado el coldown puede disparar
        if (vision.GetComponent<Detect>().Dentro() && puedoDisparar)
        {
            puedoDisparar = false;
            Dispara();

        }

    }

    void Dispara()
    {
        gameObject.GetComponent<Patrol>().Spray();
        Invoke("EfectuaDisparo", 0.5f);//Tiene que tener el mismo tiempo de invocacion que el metedo spray de patrol
    }

    void EfectuaDisparo()
    {
        if (vision.GetComponent<Detect>().LeVeo())
        {
            GameObject.FindWithTag("Player").GetComponent<Controller>().Stuned();
        }
        Invoke("PuedesDisparar", 4);//4 segundos para que pueda volver a disparar
    }

    void PuedesDisparar()
    {
        puedoDisparar = true;
    }
}
