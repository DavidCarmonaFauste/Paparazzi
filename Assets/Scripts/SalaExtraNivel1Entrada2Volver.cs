using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaExtraNivel1Entrada2Volver : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3 (-36.03f, 28.21f, 0);
        }

    }
}
