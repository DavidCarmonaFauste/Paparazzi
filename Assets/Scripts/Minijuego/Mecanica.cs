using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica : MonoBehaviour {
    int colisiones = 0;
    bool dentro;
    public int fotos = 0;
	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.tag != "topeH" && other.tag != "topeV")
        {
            colisiones++;
            dentro = true;
		}
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "topeH" && other.tag != "topeV")
        {
            colisiones--;
            dentro = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "topeH" && other.tag != "topeV")
        {
            
            dentro = true;
        }
    }
    void Update()
    {
        if (dentro && Input.GetMouseButtonDown(0))
            fotos = fotos + colisiones;
    }

}