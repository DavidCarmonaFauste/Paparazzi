using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaExtraNivel1Entrada1Volver : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3 (-53.05f, 17.1766f, 0);
        }

    }
}
