using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public int camaras, carretes, loot;
    public int puntuacionMinijuego;

	private bool Nivel1S = false, Nivel2S = false, Nivel3S = false;

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

	public string SiguienteEscena()
	{
		string actual;
		string siguiente = SceneManager.GetActiveScene().name; //Lo pongo como la actual porque hay que poner esto, o un caso default

		actual = SceneManager.GetActiveScene ().name;

		switch (actual) 
		{
		case ("Nivel1"):
			siguiente = ("Minijuego");
			break;
		case ("Minijuego"):
			siguiente = ("Nivel1"); //Está puesto nivel 1, hay que hacer otra escena con botones y tal a modo de transición, con la de puntuaciones y tal
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

	public void GuardaListaUsuarios (string username)
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

	public string CargaListaUsuarios(string username)
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

	public void GuardaUsuario (string username, bool Nivel1S, bool Nivel2S, bool Nivel3S, int MPuntuacion1, int MPuntuacion2, int MPuntuacion3, string ultimonivel)
	{
        StreamWriter archivo;
        archivo = new StreamWriter(username);

        archivo.WriteLine("Usuario " + username);
        archivo.WriteLine("Nivel1 " + Nivel1S);
        archivo.WriteLine("MejorPuntos Nivel1 " + MPuntuacion1);
        archivo.WriteLine("Nivel2 " + Nivel2S);
        archivo.WriteLine("MejorPuntos Nivel2 " + MPuntuacion2);
        archivo.WriteLine("Nivel3 " + Nivel3S);
        archivo.WriteLine("MejorPuntos Nivel3 " + MPuntuacion3);
    }

	public void CargaUsuario (string nombrearchivo, out string username, out bool Nivel1S, out bool Nivel2S, out bool Nivel3S, out int MP1, out int MP2, out int MP3)
	{
        StreamReader archivo;
        archivo = new StreamReader(nombrearchivo);

        string dato;
        string[] datoS;

        Nivel1S = false; Nivel2S = false; Nivel3S = false; MP1 = 0; MP2 = 0; MP3 = 0; username = null;

        while (!archivo.EndOfStream)
        {
            dato = archivo.ReadLine();
            datoS = dato.Split(' ');

            if (datoS[0] == "Usuario")
                username = datoS[1];
            else if (datoS[0] == "Nivel1")
                Nivel1S = bool.Parse(datoS[1]);
            else if (datoS[0] == "MejorPuntos" && datoS[1] == "Nivel1")
                MP1 = int.Parse(datoS[2]);
            else if (datoS[0] == "Nivel2")
                Nivel2S = bool.Parse(datoS[1]);
            else if (datoS[0] == "MejorPuntos" && datoS[1] == "Nivel2")
                MP2 = int.Parse(datoS[2]);
            else if (datoS[0] == "Nivel3")
                Nivel3S = bool.Parse(datoS[1]);
            else if (datoS[0] == "MejorPuntos" && datoS[1] == "Nivel3")
                MP3 = int.Parse(datoS[2]);
        }
	}

    public float Puntuacion ()
    {
        float puntos = 0;

        GameObject Crono;

        Crono = GameObject.FindGameObjectWithTag("Cronometro");
        float loot; float fMini; float fOp; float Tiempo;

        loot = Loot();
        Tiempo = GameObject.FindWithTag("Cronometro").GetComponent<Cronometro>().FinPartida();

        //puntos = fMini * 0.55f + fOp * 0.25f + loot * 0.1f + Tiempo * 0.1f;

        return puntos;
    }
}