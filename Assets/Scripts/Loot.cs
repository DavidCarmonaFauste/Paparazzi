using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
	int ptosLoot = 1000;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            int indiceNivel = GameManager.instance.NivelActual()[GameManager.instance.NivelActual().Length];
            PlayLoot.PlaySound();
            GameManager.instance.loot++;
			GameManager.instance.SumaPuntos (ptosLoot, "loot", indiceNivel);
            Destroy(this.gameObject);
        }
    }
}
