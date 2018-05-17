using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cronometro : MonoBehaviour {

    public Text crono;
    public bool cuentaAtras;
    public float tiempo;

    private float starTime;
    private bool fin = false;

    void Start () {
        starTime = Time.time;
	}
	
	void Update () {

        tiempo = Time.time - starTime;

        int min = ((int)tiempo / 60);
        int seg = (int)(tiempo % 60);

        // si estamos en el minijuego la cuenta del cronómetro es hacia atrás
        if (cuentaAtras)
        {
            min = 1 - min;
            seg = 30 - seg;

            // si el tiempo llega a 0, se acaba el minijuego
            if (min == 0 && seg == 0)
            {
                GameManager.instance.FinMinijuego();
            }
        }

        string minutos = min.ToString();
        string segundos = seg.ToString("0");

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
