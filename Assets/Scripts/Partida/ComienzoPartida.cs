using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ComienzoPartida : Comenzar {
    public GameObject fondo;
    public GameObject jugador;
    public GameObject jugador2;
    public Grid matriz;
    public GameObject energiaNerd;
    public GameObject energiaSicario;
    public GameObject transicion;
    private string nombreEscena;
    private float vidaOriginal;

    // Use this for initialization
    void Start () {
        Instantiate(fondo);
        Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(jugador2);
        Instantiate(energiaNerd);
        Instantiate(energiaSicario);
        vidaOriginal = jugador.GetComponent<Mazo>().GetVida();
        SpriteRenderer spriteFondo = GameObject.FindGameObjectWithTag("Fondo").GetComponent<SpriteRenderer>();
        SpriteRenderer spriteBarrera = GameObject.Find("Barricada").GetComponent<SpriteRenderer>();
        int numero = Random.Range(1, 3);
       
        if(numero==1)
        {
            spriteFondo.sprite = Resources.Load<Sprite>("Sprites/Partida/Arcade");
            spriteBarrera.sprite= Resources.Load<Sprite>("Sprites/Partida/Barrera_Arcade");
        }
        else if (numero == 2)
        {
            spriteFondo.sprite = Resources.Load<Sprite>("Sprites/Partida/Callejon");
            spriteBarrera.sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Callejon");

        }
        else 
        {
            spriteFondo.sprite = Resources.Load<Sprite>("Sprites/Partida/Parque");
            spriteBarrera.sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Parque");
        }

		if (nivel % 3 == 0)
		{
			if (audioFondoBailarines != null)
			{
				audioFondoBailarines.Play();
			}
		}
		else
		{
			if (audioFondoTrafico != null)
			{
				audioFondoTrafico.Play();
			}
		}
	}
    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    // Update is called once per frame
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().GetVida() <= 0)
        {
            GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().vidaBase = vidaOriginal;
            nombreEscena = "Nerd_Derrota";
            LoadScene();
        }
    }
}
