using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavMesh : MonoBehaviour {

    private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>(); 
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
	}
}
