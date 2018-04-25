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
        /*if (hijo.rotation.eulerAngles.x > -225 || hijo.rotation.x < 135)
            anim.SetTrigger("Izquierda");

        else if (hijo.rotation.eulerAngles.x > -135 || hijo.rotation.x < -45)
            anim.SetTrigger("Arriba");

        else if (hijo.rotation.eulerAngles.x > -315 || hijo.rotation.x < -225)
            anim.SetTrigger("Abajo");
        else
            anim.SetTrigger("Derecha");
            */
            transform.position = hijo.position;
            
	}
}
