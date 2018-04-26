using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

class Nivel
{
	// Variables para guardar de dónde viene la puntuación, de cara a la pantalla de puntuación
	public int puntos,
				ptsMinijuego, // puntos para el nivel conseguidos en el minijuego
				ptsFotoOp, // puntos para el nivel conseguidos por fotos a famosos opcionales
				ptsBombillas, // puntos para el nivel conseguidos por bombillas extra
				ptsCarretes, // puntos para el nivel conseguidos por carretes extra
				ptsLoot, // puntos para el nivel conseguidos por coleccionables cogidos
				penalTiempo; // penalización por tiempo

    public bool minijuego; // Es true si se ha entrado en el minijuego de nivel

	// Constructor
	public Nivel(string _nombre)
	{
		string nombre = _nombre; // Nombre del nivel, ejemplo: Nivel1

		// Inicialización
		puntos = 0;
		ptsMinijuego = 0;
		ptsFotoOp = 0;
		ptsBombillas = 0;
		ptsCarretes = 0;
		ptsLoot = 0;
		penalTiempo = 0;

        minijuego = false;
	}


}

public class GameManager : MonoBehaviour {

	Nivel nivel1;

	public int bombillas, carretes, loot; //Las bombillas se usan para stunnear y los carretes para las fotos
                                          //puntuacionMinijuego,
                                          //puntos;

    public int carreteEspecial = 1;

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

		// Inicialización
		bombillas = 3;
		carretes = 3;
		loot = 0;
		//puntos = 0;
		nivel1 = new Nivel ("nivel1");
	}

	void Update()
	{
		//Debug.Log (nivel1.puntos);
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
		return bombillas;
    }

    public int Carretes()
    {
        return carretes;
    }
    
    public int CarreteEspecial()
    {
        return carreteEspecial;
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

   /*public float Puntuacion ()
    {
        

        GameObject Crono;

        Crono = GameObject.FindGameObjectWithTag("Cronometro");
        float loot; float fMini; float fOp; float Tiempo;

        loot = Loot();
        Tiempo = GameObject.FindWithTag("Cronometro").GetComponent<Cronometro>().FinPartida();

        //puntos = fMini * 0.55f + fOp * 0.25f + loot * 0.1f + Tiempo * 0.1f;

        return puntos;
    }*/

	// Aumenta la puntuación en una cantidad determinada y guarda de dónde viene la puntuación
	public void SumaPuntos(int cantidad, string motivo)
	{
		nivel1.puntos += cantidad;

		/*	"minijuego"	-> ptosMinijuego
		 * 	"opcional"	-> ptosFotoOp
		 * 	"bombillas"	-> ptosBombillas
		 * 	"carretes"	-> ptosCarretes
		 * 	"loot"	-> ptosLoot
		 */
		switch (motivo) 
		{
		case "minijuego":
			nivel1.ptsMinijuego += cantidad;
			break;
		case "opcional":
			nivel1.ptsFotoOp += cantidad;
			break;
		case "bombillas":
			nivel1.ptsBombillas += cantidad;
			break;
		case "carretes":
			nivel1.ptsCarretes += cantidad;
			break;
		case "loot":
			nivel1.ptsLoot += cantidad;
			break;
		}
	}
    public void Minijuego()
    {
       nivel1.minijuego = true;
    }
    public bool MinijuegoTerminado()
    {
        return nivel1.minijuego;
    }

    public void Pierde()
    {
        SceneManager.LoadScene("FinPartida");
    }

	// FIN DEL NIVEL 1
	public void FinN1()
	{
		// Puntuación por carretes extra
		for (int i = 0; i < carretes; i++)
			SumaPuntos (5, "carretes");

		// Puntuación por bombillas extra
		for (int i = 0; i < bombillas; i++) {
			
			SumaPuntos (10, "bombillas");
			//Debug.Log ("Ptos Bombilla " + nivel1.ptsBombillas);
		}


        // Ir a la pantalla de puntuación de este nivel
        SceneManager.LoadScene("Nivel1");
    }

	public void GoToPuntuacionN1()
	{
		// Ir a la escena de puntuación del nivel 1
		SceneManager.LoadScene("PuntuacionN1");
		Debug.Log("PUNTUACION = " + nivel1.puntos);
	}
}