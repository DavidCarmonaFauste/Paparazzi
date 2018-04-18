using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public bool leVeo = false;//Le ves
    public bool dentro = false;//Esta dentro del collider
    public bool frentebol = false;//Esta de fernte
	public bool noHayOtroGuardia = false;//Para saber a que guardia disparar

    public LayerMask whatToHit;

	GameObject whoToHit;//Con que colisiona el raycast(Obstaculos, frente y espalda)


    private void FixedUpdate()
    {
        if (whoToHit != null)
        {
            RaycastHit2D hit;

            Vector2 dir = new Vector2(whoToHit.transform.position.x - transform.position.x, whoToHit.transform.position.y - transform.position.y).normalized;

            if (dentro)
            {
                float dist = Vector2.Distance(whoToHit.transform.position, transform.position);

                hit = Physics2D.Raycast(transform.position, dir, dist, whatToHit);

                if (hit.collider.CompareTag("Espalda") || hit.collider.CompareTag("Frente"))
                {
                    frentebol = false;
                    leVeo = true;
                    Debug.DrawRay(transform.position, dir, Color.green);
                    if (hit.collider.CompareTag("Frente"))
                        frentebol = true;
                    else
                        frentebol = false;
                }
                else
                {
                    leVeo = false;
                    Debug.DrawRay(transform.position, dir, Color.red);
                }
            }
            else
            {
                leVeo = false;
                Debug.DrawRay(transform.position, dir, Color.red);
            }
        }
        else
            leVeo = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = col.gameObject;

		if (go.CompareTag("Frente") || go.CompareTag("Espalda") && !noHayOtroGuardia)
        {
			noHayOtroGuardia = true;
            dentro = true;
            whoToHit = go.transform.parent.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        GameObject go = col.gameObject;

		if (go.CompareTag("Frente") || go.CompareTag("Espalda"))
		{
			dentro = false;
			noHayOtroGuardia = false;
		}

        

    }
    public bool LeVeo()
    {
        return leVeo;
    }

    public void Stunn()
    {
        whoToHit.GetComponent<Patrol>().Stunned();
    }

    public bool Frente()
    {
        return frentebol;
    }
}
