using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Especificacion de la clase comenzar para la logica sobre una partida single player
/// </summary>
public class ComenzarPartidaSolo : Comenzar {
    public static int cantidadExp;
    public GameObject fondo;
    public static GameObject jugador;
    public Grid matriz;
    public GameObject energiaNerd;
    public GameObject transicion;
    private string nombreEscena;

	void Start () {
        Instantiate(fondo);
		Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(energiaNerd);
        NerdVictoria.cantidadExp = cantidadExp;
    }
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(nombreEscena);
    }
    void Update () {
        if (GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().GetVida() <= 0)
        {
            nombreEscena = "Nerd_Derrota";
            StartCoroutine(LoadScene());
        }
    }
}
