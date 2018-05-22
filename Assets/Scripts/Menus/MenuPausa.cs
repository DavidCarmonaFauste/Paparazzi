using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour {

	public GameObject pauseMenuUI;
	public string menu;

	/*void Start ()
	{
		Time.timeScale = 1f;
	}*/

	void Update () 
	{
      	if (Input.GetKeyDown (KeyCode.Escape) && GameManager.instance.AllowPausa()) 
		{
			if (GameManager.instance.GameIsPaused()) 
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
		GameManager.instance.SetPause (false);
	}

	void Pause ()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f; 
		GameManager.instance.SetPause (true);
	}

	public void Quit ()
	{
		Application.Quit();
	}

	public void GoToMenu ()
	{
        GameManager.instance.GoToMenu();
	}
		
}
