using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cronómetro : MonoBehaviour {

    public Text crono;
    private float starTime;
    private bool fin = false;

	void Start () {
        starTime = Time.time;
	}
	
	void Update () {

        if (fin)
            return;
        float tiempo = Time.time - starTime;

        string minutos = ((int)tiempo / 60).ToString();
        string segundos = (tiempo % 60).ToString("0");

        if (int.Parse(segundos) < 10)
            segundos = "0" + segundos;
        crono.text = minutos + ":" + segundos;
	}

    public void FinPartida()
    {
        fin = true;
        crono.color = Color.yellow;
    }
}
