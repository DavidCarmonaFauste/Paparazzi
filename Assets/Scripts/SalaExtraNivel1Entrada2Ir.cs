using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaExtraNivel1Entrada2Ir : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3 (8f, -8.6f, 0);
        }

    }
}
