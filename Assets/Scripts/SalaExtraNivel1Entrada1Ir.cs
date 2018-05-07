using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalaExtraNivel1Entrada1Ir : MonoBehaviour {

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3 (-7.92f, -26.6f, 0);
        }
    }
}
