using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cronometro : MonoBehaviour {

    public Text crono;
    private float starTime;
    private bool fin = false;
    public float tiempo;


    void Start () {
        starTime = Time.time;
	}
	
	void Update () {

        tiempo = Time.time - starTime;

        string minutos = ((int)tiempo / 60).ToString();
        string segundos = (tiempo % 60).ToString("0");

        if (int.Parse(segundos) < 10)
            segundos = "0" + segundos;
        crono.text = minutos + ":" + segundos;
	}

    public float FinPartida()
    {
        fin = true;
        crono.color = Color.yellow;
        return tiempo;
    }
}
