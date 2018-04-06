using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public int camaras, carretes, loot;

	public static GameManager instance = null;

	void Awake()
    {
		if (instance == null)
        {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else Destroy(this.gameObject);
	}

    public int Bombillas()
    {
        return camaras;
    }

    public int Carretes()
    {
        return carretes;
    }

    public int Loot()
    {
        return loot;
    }
}