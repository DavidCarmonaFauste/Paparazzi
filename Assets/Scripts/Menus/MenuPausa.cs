using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public string menu;

	void Start ()
	{
		Time.timeScale = 1f;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused) 
			{
				Resume ();	
			} 
			else 
			{
				Pause ();
			}
		}
	}
		
	public void Resume ()
	{
		pauseMenuUI.SetActive (false);
		// timeScale modifica la velocidad a la que pasa el tiempo dentro del juego (va de 0 a 1)
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	void Pause ()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f; 
		GameIsPaused = true;
	}

	public void Quit ()
	{
		Application.Quit();
	}

	public void GoToMenu ()
	{
		SceneManager.LoadScene (menu);
	}
		
}
