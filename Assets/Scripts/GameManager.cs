﻿using System.Collections;
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
                penalTiempo, // penalización por tiempo
                puntuacionMaxima;

    public bool minijuego; // Es true si se ha entrado en el minijuego de nivel
    public bool terminado; // Es true si el nivel se ha terminado

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
        terminado = false;
	}

	// Devolver la puntuación total obtenida
	public int PuntuacionTotal()
	{
		return(ptsLoot + ptsMinijuego + ptsFotoOp + ptsCarretes + ptsBombillas - penalTiempo);
	}

	// Devolver el texto con la puntuación del nivel
	public string PuntuacionFinalText()
	{
		return("Coleccionables recogidos: " + ptsLoot + " puntos\n" + 
			"Bombillas y carretes sin usar: " + (ptsBombillas + ptsCarretes) + " puntos\n" +
			"Fotos a famosos secundarios: " + ptsFotoOp + " puntos\n" +
			"Fotos al famoso principal: " + ptsMinijuego + " puntos\n" + 
			"Penalización por tiempo: " + ptsLoot + " puntos\n" +
			"TOTAL: " + PuntuacionTotal() + " puntos\n");
	}



}

public class GameManager : MonoBehaviour {

	Nivel nivel1;
    Nivel nivel2;
	public int bombillas, carretes, loot; //Las bombillas se usan para stunnear y los carretes para las fotos
                                          //puntuacionMinijuego,
                                          //puntos;

    public int carreteEspecial = 1;

    private bool Nivel1S = false, Nivel2S = false, Nivel3S = false,
                tutoVisto = false;

    public static GameManager instance = null;

    string actual;

	bool gameIsPaused = false;

    void Awake()
    {
		if (instance == null)
        {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
        }
		else Destroy(this.gameObject);

		nivel1 = new Nivel ("nivel1");
        actual = SceneManager.GetActiveScene().name;
        Partida();

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


	// Inicialización de objetos
	public void InicializaObjetos ()
	{
		bombillas = 3;
		carretes = 3;
		loot = 0;
	}

	public void PickBombilla ()
	{
		bombillas++;
	}

	public void PickCarrete ()
	{
		carretes++;
	}

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
        int indiceNivel = int.Parse(actual[actual.Length-1].ToString());
        
        switch (indiceNivel)
        {
            case 1:
                // Nivel 1
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
                break;
            case 2:
                // Nivel 2
                switch (motivo)
                {
                    case "minijuego":
                        nivel2.ptsMinijuego += cantidad;
                        break;
                    case "opcional":
                        nivel2.ptsFotoOp += cantidad;
                        break;
                    case "bombillas":
                        nivel2.ptsBombillas += cantidad;
                        break;
                    case "carretes":
                        nivel2.ptsCarretes += cantidad;
                        break;
                    case "loot":
                        nivel2.ptsLoot += cantidad;
                        break;
                }
                break;
        }
       
	}

	public int GetPuntos()
	{
        int indiceNivel = int.Parse(actual[actual.Length - 1].ToString());
        int puntos = 0;
		switch (indiceNivel) {
		case 1:
			puntos = PuntosN1();
			break;
		}

		return puntos;
	}

	int PuntosN1()
	{
		return nivel1.puntos;
	}

    public void Minijuego()
    {
        if(actual == "Nivel1")
          nivel1.minijuego = true;
        else if(actual == "Nivel2")
            nivel2.minijuego = true;
    }

    public void GoToMiniJuego()
    {
        int indiceNivel = int.Parse(actual[actual.Length - 1].ToString());
        switch (indiceNivel)
        {
            case 1:
                // Nivel 1
                SceneManager.LoadScene("Minijuego1");
                break;
            case 2:
                // Nivel 2
                SceneManager.LoadScene("Minijuego2");
                break;
        }
        actual = "Minijuego" + indiceNivel;

    }
    public bool MinijuegoTerminado()
    {


        switch (actual)
        {

            case "Nivel1":
                return nivel1.minijuego;
                
            case "Nivel2":
                return nivel2.minijuego;
                
            default:
                return false;
        }
    }

    public string NivelActual()
    {
        return actual;
    }
    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1");
        actual = "nivel1";
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("Nivel2");
        actual = "nivel2";
    }
    public void Pierde()
    {
        SceneManager.LoadScene("FinPartida");
        actual = "FinPartida";
    }

	// FIN DEL NIVEL 1
	public void FinMinijuego()
	{
        int indiceNivel = int.Parse(actual[actual.Length - 1].ToString());
        // Puntuación por carretes extra
        for (int i = 0; i < carretes; i++)
			SumaPuntos (100, "carretes");

		// Puntuación por bombillas extra
		for (int i = 0; i < bombillas; i++) {
			
			SumaPuntos (250, "bombillas");
			//Debug.Log ("Ptos Bombilla " + nivel1.ptsBombillas);
		}
        // Ir a la pantalla de puntuación de este nivel
        switch (indiceNivel)
        {  
            case 1:
                // Nivel 1
                
                SceneManager.LoadScene("Nivel1");
                nivel1.minijuego = true;


                break;
            case 2:
                // Nivel 1
                SceneManager.LoadScene("Nivel2");
                nivel2.minijuego = true;
                break;
        }
        actual = "Nivel" + indiceNivel;
        
    }

    
	public void GoToPuntuacion() 
	{
        int indiceNivel = int.Parse(actual[actual.Length - 1].ToString());
        switch (indiceNivel) 
		{
		case 1:
                // Nivel 1
                GuardaPartida();
                if (nivel1.puntos > nivel1.puntuacionMaxima)
                    nivel1.puntuacionMaxima = nivel1.puntos;
			SceneManager.LoadScene("N1Puntuacion");
                nivel1.terminado = true;
			break;
        case 2:
                // Nivel 2
                GuardaPartida();
                if (nivel2.puntos > nivel2.puntuacionMaxima)
                    nivel2.puntuacionMaxima = nivel2.puntos;
                SceneManager.LoadScene("N2Puntuacion");
                nivel2.terminado = true;
                break;
        }

        actual = "N" + indiceNivel + "Puntuacion";

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        actual = "Menu";
    }


	// Devolver la puntuación total obtenida
	public int PuntuacionTotalNivel()
	{
        int indiceNivel = int.Parse(actual[actual.Length - 1].ToString());
        int puntuacion = 0;
		switch (indiceNivel) 
		{
		case 1:
			puntuacion = nivel1.PuntuacionTotal();
			break;
            case 2:
                puntuacion = nivel2.PuntuacionTotal();
                break;
        }

		return puntuacion;
	}

	public string TextoPuntuacion()
	{
        int indiceNivel = int.Parse(actual[actual.Length - 1].ToString());
        string texto = "";
		switch (indiceNivel) 
		{
		case 1:
			texto = nivel1.PuntuacionFinalText ();
			break;
            case 2:
                texto = nivel2.PuntuacionFinalText();
                break;
        }

		return texto;
	}

    public void Partida()
    {
        if (File.Exists("PartidaGuardada"))
        {
            StreamReader entrada = new StreamReader("PartidaGuardada");
            string s;
            s = entrada.ReadLine();
            while (!entrada.EndOfStream)
            {
                if (s.Split(' ')[0] == "Nivel")
                {
                    if (s.Split(' ')[1] == "1")
                        nivel1.terminado = true;

                    else if (s.Split(' ')[1] == "2")
                        nivel2.terminado = true;

                }
                else if (s.Split(' ')[0] == "Puntuacion")
                {
                    if (s.Split(' ')[1] == "1")
                        nivel1.puntuacionMaxima = int.Parse(s.Split(' ')[2]);

                    else if (s.Split(' ')[1] == "2")
                        nivel2.puntuacionMaxima = int.Parse(s.Split(' ')[2]);

                }
                
                s = entrada.ReadLine();
                
            }

                if (s.Split(' ')[1] == "1")
                    nivel1.puntuacionMaxima = int.Parse(s.Split(' ')[2]);

                else if (s.Split(' ')[1] == "2")
                    nivel2.puntuacionMaxima = int.Parse(s.Split(' ')[2]);

            
            entrada.Close(); 
        }
        
    }
    public void NuevaPartida()
    {
        if (File.Exists("PartidaGuardada"))
        {
            File.Delete("PartidaGuardada");
        }
    }

    public void GuardaPartida()
    {
        int indiceNivel = int.Parse(actual[actual.Length - 1].ToString());
        StreamWriter salida = new StreamWriter("PartidaGuardada");
        if (indiceNivel == 1)

        {
            salida.WriteLine("Nivel 1");
            salida.Write("Puntuacion 1 " + nivel1.puntuacionMaxima);
        }
        else if (indiceNivel == 2)
        {
            salida.WriteLine("Nivel 2");
            salida.WriteLine("Puntuacion 2 " + nivel2.puntuacionMaxima);
        }
        salida.Close();

    }



	public void SetPause(bool pause)
	{
		gameIsPaused = pause;
	}

	public bool GameIsPaused()
	{
		return gameIsPaused;
	}

    //Tutorial cámaras
    public void VistoTutorial()
    {
        tutoVisto = true;
    }

    //Devuelve true si ya se ha visto el tutorial
    public bool CheckTutorial()
    {
        return tutoVisto;
    }
}