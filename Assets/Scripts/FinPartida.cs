using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinPartida : MonoBehaviour {
    int indiceNivel;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && GameManager.instance.MinijuegoTerminado())
        {
            indiceNivel = GameManager.instance.NivelActual()[GameManager.instance.NivelActual().Length];

            GameManager.instance.GoToPuntuacion(indiceNivel);
        }
    }
}
