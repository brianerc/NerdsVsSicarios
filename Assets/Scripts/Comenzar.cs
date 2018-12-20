using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase sobre la jerarquia de comenzar partida. En esta clase se implementan codigo comun a las partidas
/// sean partidas single player or multiplayer
/// </summary>
public abstract class Comenzar : MonoBehaviour {
    public float separacionLanzadores;
    public static int nivel=-1;
    public static int nivelJugador = -1;
	public AudioSource audioFondoTrafico;
	public AudioSource audioFondoBailarines;
	public AudioSource audioFondoPunkGirls;
	public AudioSource audioFondoDeporte;


	void Start () {		
	}
	
	void Update () {
		
	}
}
