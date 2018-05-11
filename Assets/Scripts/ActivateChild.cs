using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChild : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!GameManager.instance.CheckTutorial() && col.gameObject.CompareTag ("Player")) 
		{
			this.transform.GetChild (0).gameObject.SetActive (true);
		}
	}
}
