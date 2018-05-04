using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaMinijuego : MonoBehaviour {

		void OnCollisionEnter2D (Collision2D col)
		{
            if (col.gameObject.tag == "Player"&& !GameManager.instance.MinijuegoTerminado() && GameManager.instance.NivelActual() == "Nivel1")
            {
                SceneManager.LoadScene(GameManager.instance.SiguienteEscena());
                GameManager.instance.Minijuego();
            }
			
		}

}
