using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinPartida : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && GameManager.instance.nivel1.minijuego)
        {
            Debug.Log("ASDGVAKSJDFHA");
        }

    }
}
