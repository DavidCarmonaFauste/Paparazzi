using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
	int actual = -1;

	void Awake() {
		if (!GameManager.instance.MinijuegoTerminado ()) 
		{
			GameManager.instance.SetPause (true);
			Time.timeScale = 0f;
			actual = 0;
			this.transform.GetChild (actual).gameObject.SetActive (true);	//Activar la primera imagen al empezar el nivel
		}
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && actual != 2 && actual != -1) {
			this.transform.GetChild (actual).gameObject.SetActive (false);
			actual++;
			this.transform.GetChild (actual).gameObject.SetActive (true);
		} else if (Input.GetKeyDown (KeyCode.Space) && actual == 2 && actual != -1) {
			this.transform.GetChild (actual).gameObject.SetActive (false);
			GameManager.instance.SetPause (false);
			Time.timeScale = 1f;
		}
	}
}
