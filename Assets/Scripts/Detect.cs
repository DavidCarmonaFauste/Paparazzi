using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour {

    public bool leVeo = false;
    public bool dentro = false;

    public LayerMask whatToHit;


    private void FixedUpdate()
    {
        GameObject go = GameObject.FindWithTag("Player");
        RaycastHit2D hit;

        Vector2 dir = new Vector2(go.transform.position.x - transform.position.x, go.transform.position.y - transform.position.y).normalized ;

        if (dentro)
        {
            float dist = Vector2.Distance(go.transform.position, transform.position);

            hit = Physics2D.Raycast(transform.position, dir, dist, whatToHit);

            if (hit.collider.CompareTag("Player"))
            {
                leVeo = true;
                Debug.DrawRay(transform.position, dir, Color.green);
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = col.gameObject;

        if (go.CompareTag("Player"))
            dentro = true;

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        GameObject go = col.gameObject;

        if (go.CompareTag("Player"))
            dentro = false;

    }

    public bool LeVeo()
    {
        return leVeo;
    }
    public bool Dentro()
    {
        return dentro;
    }
}
