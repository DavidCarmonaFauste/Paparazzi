using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaMinijuego : MonoBehaviour {
    int indiceNivel;
        void OnCollisionEnter2D (Collision2D col)
		{
            if (col.gameObject.tag == "Player"&& !GameManager.instance.MinijuegoTerminado() && GameManager.instance.NivelActual() == "Nivel1")
            {
            indiceNivel = int.Parse(GameManager.instance.NivelActual()[GameManager.instance.NivelActual().Length - 1].ToString());

            GameManager.instance.GoToMiniJuego(indiceNivel);
            }
			
		}

}
