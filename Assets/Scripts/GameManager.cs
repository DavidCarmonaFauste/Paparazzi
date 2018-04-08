using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public int camaras, carretes, loot;

	private bool Nivel1S, Nivel2S, Nivel3S;

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

	public Scene SiguienteEscena()
	{
		string actual;
		Scene siguiente = SceneManager.GetActiveScene(); //Lo pongo como la actual porque hay que poner esto, o un caso default

		actual = SceneManager.GetActiveScene ().name;

		switch (actual) 
		{
		case ("Nivel1"):
			siguiente = SceneManager.GetSceneByName ("Minijuego");
			break;
		case ("Minijuego"):
			siguiente = SceneManager.GetSceneByName ("Nivel1"); //Está puesto nivel 1, hay que hacer otra escena con botones y tal a modo de transición, con la de puntuaciones y tal
			break;
		}

		return siguiente;
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

	public void GuardaUsuarios (string username)
	{
		StreamReader entrada;
		StreamWriter salida;
		salida = new StreamWriter ("users");
		string[] backup;
		backup = new string[150];
		int i = 0, a = 0;

		if (!File.Exists ("users")) 
		{
			salida.WriteLine ("Lista de usuarios de Paparazzi Infilitration");
			salida.WriteLine ();
			salida.Close ();
		} 

		else 
		{
			entrada = new StreamReader ("users");

			while (i < backup.Length - 1) 
			{
				backup [i] = entrada.ReadLine ();
				i++;
			}

			while (backup [a] != null) 
			{
				salida.WriteLine (backup [a]);
				a++;
			}

			salida.WriteLine (username);
			salida.Close ();
		}

	}

	public string CargaUsuarios(string username)
	{
		StreamReader entrada;
		entrada = new StreamReader ("users");
		bool encontrado = false;

		while (!entrada.EndOfStream && !encontrado) 
		{
			if (username == entrada.ReadLine ()) 
			{
				encontrado = true;
			}
		}

		if (!encontrado)
			username = "error";
		
		return username;
	}

	public void GuardaArchivo ()
	{
		
	}

	public void CargaArchivo (string nombrearchivo)
	{
		
	}
}