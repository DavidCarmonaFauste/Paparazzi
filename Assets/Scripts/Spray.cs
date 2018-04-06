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

        if (vision.GetComponent<Detect>().Dentro() && puedoDisparar)
        {
            puedoDisparar = false;
            Dispara();

        }

    }

    void Dispara()
    {
        gameObject.GetComponent<Patrol>().Spray();
        Invoke("EfectuaDisparo", 0.5f);
    }

    void EfectuaDisparo()
    {
        if (vision.GetComponent<Detect>().LeVeo())
        {
            GameObject.FindWithTag("Player").GetComponent<Controller>().Stuned();
        }
        Invoke("PuedesDisparar", 4);
    }

    void PuedesDisparar()
    {
        puedoDisparar = true;
    }
}
