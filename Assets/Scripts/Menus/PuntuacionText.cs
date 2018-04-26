using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntuacionText : MonoBehaviour {

	Text stringTexto;
	public int indNivel;

	void Awake()
	{
		stringTexto = gameObject.GetComponent<Text>();
	}

	void Start()
	{
		SetText ();
	}

	void SetText () {
		stringTexto.text = GameManager.instance.TextoPuntuacion (indNivel);
	}
	//GameManager.instance.PuntuacionTotalNivel (indNivel).ToString();									

}
