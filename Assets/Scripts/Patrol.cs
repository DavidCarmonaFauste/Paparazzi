using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public Transform[] patrolPoints;
	public float speed;
	Transform currentPatrol;
	int currentPatrolIndex;
	Rigidbody2D rb;

    float realSpeed;

    void Start ()
	{
        realSpeed = speed;
		rb = GetComponent<Rigidbody2D> ();
		currentPatrolIndex = 0;
		currentPatrol = patrolPoints [currentPatrolIndex];

	}
	

	void Update () 
	{
		Vector2	dir = new Vector2 (currentPatrol.position.x - transform.position.x, currentPatrol.position.y - transform.position.y).normalized;
		rb.MovePosition (rb.position + dir * Time.fixedDeltaTime * speed);

		if(Vector3.Distance(transform.position,currentPatrol.position)<0.1f)
			{
				if (currentPatrolIndex + 1 < patrolPoints.Length)
					currentPatrolIndex++;
				else 
				{
					currentPatrolIndex = 0;
				}
			currentPatrol = patrolPoints [currentPatrolIndex];
			}
			rb.MoveRotation(Mathf.LerpAngle(rb.rotation, Vector2.SignedAngle(Vector2.up, dir), 0.1f));
	}

    public void Stunned()
    {
        speed = 0;
        Invoke("NoStunned", 2);
    }
    void NoStunned()
    {
        speed = realSpeed;
    }

    public void Spray()
    {
        speed = 0;
        Invoke("NoStunned", 0.5f);
    }


}