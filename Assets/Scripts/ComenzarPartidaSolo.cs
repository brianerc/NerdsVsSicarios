﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Especificacion de la clase comenzar para la logica sobre una partida single player
/// </summary>
public class ComenzarPartidaSolo : Comenzar {
    public static int cantidadExp;
    public static string zona;
    public GameObject fondo;
    public static GameObject jugador;
	public Grid matriz;
    public GameObject energiaNerd;
    public GameObject transicion;
    private string nombreEscena;
    public GameObject jugadorDeFootballBase;
    public GameObject jugadorDeFootballMedio;
    public GameObject jugadorDeFootballEstrella;
    public GameObject bailarinBase;
    public GameObject bailarinMedio;
    public GameObject bailarinEstrella;
    public GameObject punkGirlBase;
    public GameObject punkGirlMedia;
    public GameObject punkGirlEstrella;
    private float vidaOriginal;
    void Start () {

        Instantiate(fondo);
		Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(energiaNerd);
        NerdVictoria.cantidadExp = cantidadExp;
        vidaOriginal = jugador.GetComponent<Mazo>().GetVida();
        
        CargarGeneradores();
        if (zona == "Backstreet")
        {
            GameObject.FindGameObjectWithTag("Fondo").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Callejon");
            GameObject.Find("Barricada").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Callejon");
        }
        if (zona == "Park")
        {
            GameObject.FindGameObjectWithTag("Fondo").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Parque");
            GameObject.Find("Barricada").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Parque");
        }
        if (zona == "Arcade")
        {
            GameObject.FindGameObjectWithTag("Fondo").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Arcade");
            GameObject.Find("Barricada").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Arcade");
        }
        if (zona == "Boss Level")
        {
            GameObject.FindGameObjectWithTag("Fondo").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Mansion");
            GameObject.Find("Barricada").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Mansion");
        }

		CargarFondosAudios();
		

	}

	private void CargarFondosAudios()
	{
		if (nivel == 1 || nivel == 2 || nivel == 3)
		{
			if (audioFondoBailarines != null)
			{
				audioFondoBailarines.Play();
			}
		}
		else if (nivel == 4 || nivel == 5 || nivel == 6)
		{
			if (audioFondoPunkGirls != null)
			{
				audioFondoPunkGirls.Play();
			}
		}
		else
		{
			if (audioFondoDeporte != null)
			{
				audioFondoDeporte.Play();
			}
			else
			{
				if (audioFondoTrafico != null)
				{
					audioFondoTrafico.Play();
				}
			}
		}
	}

	private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    void Update () {
        if (GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().GetVida() <= 0)
        {
            GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().vidaBase =vidaOriginal;
            nombreEscena = "Nerd_Derrota";
            LoadScene();
        }
    }

    public void CargarGeneradores()
    {
        if (nivel == 1)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = bailarinBase;
                miGenerador.sicario2 = bailarinBase;
                miGenerador.sicario3 = bailarinBase;
                miGenerador.tiempoSicario1 = 15;
                miGenerador.tiempoSicario2 = 25;
                miGenerador.tiempoSicario3 = 50;
            }
        }
        else if (nivel == 2)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = bailarinBase;
                miGenerador.sicario2 = bailarinBase;
                miGenerador.sicario3 = bailarinMedio;
                miGenerador.tiempoSicario1 = 15;
                miGenerador.tiempoSicario2 = 25;
                miGenerador.tiempoSicario3 = 40;
            }
        }
        else if (nivel == 3)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = bailarinBase;
                miGenerador.sicario2 = bailarinMedio;
                miGenerador.sicario3 = bailarinEstrella;
                miGenerador.tiempoSicario1 = 15;
                miGenerador.tiempoSicario2 = 20;
                miGenerador.tiempoSicario3 = 35;
            }
        }
        else if (nivel == 4)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = punkGirlBase;
                miGenerador.sicario2 = punkGirlBase;
                miGenerador.sicario3 = punkGirlBase;
                miGenerador.tiempoSicario1 = 15;
                miGenerador.tiempoSicario2 = 20;
                miGenerador.tiempoSicario3 = 35;
            }
        }
        else if (nivel == 5)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = punkGirlBase;
                miGenerador.sicario2 = punkGirlBase;
                miGenerador.sicario3 = punkGirlMedia;
                miGenerador.tiempoSicario1 = 15;
                miGenerador.tiempoSicario2 = 20;
                miGenerador.tiempoSicario3 = 30;
            }
        }
        else if (nivel == 6)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = punkGirlBase;
                miGenerador.sicario2 = punkGirlMedia;
                miGenerador.sicario3 = punkGirlEstrella;
                miGenerador.tiempoSicario1 = 15;
                miGenerador.tiempoSicario2 = 20;
                miGenerador.tiempoSicario3 = 30;
            }
        }
        else if (nivel == 7)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = jugadorDeFootballBase;
                miGenerador.sicario2 = jugadorDeFootballBase;
                miGenerador.sicario3 = jugadorDeFootballBase;
                miGenerador.tiempoSicario1 = 10;
                miGenerador.tiempoSicario2 = 20;
                miGenerador.tiempoSicario3 = 30;
            }
        }
        else if (nivel == 8)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = jugadorDeFootballBase;
                miGenerador.sicario2 = jugadorDeFootballBase;
                miGenerador.sicario3 = jugadorDeFootballMedio;
                miGenerador.tiempoSicario1 = 10;
                miGenerador.tiempoSicario2 = 20;
                miGenerador.tiempoSicario3 = 30;
            }
        }
        else if (nivel == 9)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = jugadorDeFootballBase;
                miGenerador.sicario2 = jugadorDeFootballMedio;
                miGenerador.sicario3 = jugadorDeFootballEstrella;
                miGenerador.tiempoSicario1 = 10;
                miGenerador.tiempoSicario2 = 20;
                miGenerador.tiempoSicario3 = 30;
            }
        }
        else if (nivel == 10)
        {
            foreach (GameObject generador in GameObject.FindGameObjectsWithTag("Generador"))
            {
                Generador miGenerador = generador.GetComponent<Generador>();
                miGenerador.sicario1 = bailarinEstrella;
                miGenerador.sicario2 = punkGirlEstrella;
                miGenerador.sicario3 = jugadorDeFootballEstrella;
                miGenerador.tiempoSicario1 = 10;
                miGenerador.tiempoSicario2 = 15;
                miGenerador.tiempoSicario3 = 25;
            }
        }

    }

}
