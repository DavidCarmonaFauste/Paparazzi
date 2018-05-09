using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntuacionText : MonoBehaviour {

	Text stringTexto;
    int indiceNivel;

	void Awake()
	{
		stringTexto = gameObject.GetComponent<Text>();
	}

	void Start()
	{
		SetText ();
	}

	void SetText () {
        indiceNivel = int.Parse(GameManager.instance.NivelActual()[GameManager.instance.NivelActual().Length - 1].ToString());
        stringTexto.text = GameManager.instance.TextoPuntuacion (indiceNivel);
	}
										

}
