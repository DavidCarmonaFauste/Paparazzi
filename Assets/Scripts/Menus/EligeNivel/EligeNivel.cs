using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EligeNivel : MonoBehaviour {



    public void Activa()
    {
        gameObject.SetActive(true);
        string posible = GameManager.instance.EligeNivel();
        if (posible.Length == 3)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if(posible.Length == 2)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }

    }
    public void Desactiva()
    {
        gameObject.SetActive(false);
    }

    public void NivelElige1()
    {
        GameManager.instance.Nivel1();
    }
    public void NivelElige2()
    {
        GameManager.instance.Nivel2();
    }
    public void NivelElige3()
    {
        GameManager.instance.Nivel3();
    }
}
