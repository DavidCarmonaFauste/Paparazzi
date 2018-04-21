using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

	public Transform hijo;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        if ((hijo.rotation.x) < -225 && (hijo.rotation.x > -315) && (hijo.rotation.y > 0))
        {
            anim.Play("AndaGuardia1Izquierda");
            Debug.Log("cambia animación");
        }
        Debug.Log(hijo.eulerAngles.x);

		transform.position = hijo.position;
	}
}
