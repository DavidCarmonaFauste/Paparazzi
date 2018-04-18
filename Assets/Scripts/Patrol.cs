using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

	public Transform[] patrolPoints;
	public float speed;
	Transform currentPatrol;
	int currentPatrolIndex;
	Rigidbody2D rb;
    private NavMeshAgent agent;
    float realSpeed;

    public bool patrulla = true;

    void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		realSpeed = agent.speed;//Velocidad real 
		rb = GetComponent<Rigidbody2D> ();
		currentPatrolIndex = 0;//Punto de patrulla
		currentPatrol = patrolPoints [currentPatrolIndex];
        agent.updateRotation = false;
    }

    void Update()
    {
        if(transform.GetChild(0).GetComponent<Detect>().LeVeo())
        {

            patrulla = false;

            GameObject go = GameObject.FindWithTag("Player");
            //Vector direccion hacia donde se debe mover el guardia
            Vector2 dir = new Vector2(go.transform.position.x - transform.position.x, go.transform.position.y - transform.position.y);
            agent.SetDestination(go.transform.position);

            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, Vector2.SignedAngle(Vector2.up, dir), 0.1f));//Rotaicion del guardia
        }
        else
        {
            if(!patrulla)
                Invoke("Patrulla", 2);
            if (patrulla)
            {
                //Vector direccion hacia donde se debe mover el guardia
                Vector2 dir = new Vector2(currentPatrol.position.x - transform.position.x, currentPatrol.position.y - transform.position.y);


                agent.SetDestination(currentPatrol.position);

                if (Vector3.Distance(transform.position, currentPatrol.position) < 0.1f)
                {//Cambia el punto de patrulla actual
                    if (currentPatrolIndex + 1 < patrolPoints.Length)
                        currentPatrolIndex++;
                    else
                    {
                        currentPatrolIndex = 0;
                    }
                    currentPatrol = patrolPoints[currentPatrolIndex];

                }
                rb.MoveRotation(Mathf.LerpAngle(rb.rotation, Vector2.SignedAngle(Vector2.up, dir), 0.1f));//Rotaicion del guardia
            }
        }
    }

    public void Stunned()
    {
        agent.speed = 0;
        Invoke("NoStunned", 2);
    }
    void NoStunned()
    {
        agent.speed = realSpeed;
    }

    public void Spray()
    {
        agent.speed = 0;
        Invoke("NoStunned", 0.5f);
    }

     void Patrulla()
	{
        patrulla = true;
    }
}