using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ComienzoPartida : MonoBehaviour {
    public GameObject jugador;
    public GameObject jugador2;
    public Grid matriz;
    public GameObject fondo;
    public GameObject temporizador;
    public float separacionLanzadores;

	// Use this for initialization
	void Start () {

        Instantiate(fondo);
        Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(jugador2);
        Instantiate(temporizador);
	}

    // Update is called once per frame
    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Nerd").GetComponent<Arbol>().GetVida()<=0)
        {
            SceneManager.LoadScene("Nerd_Derrota");
        }
    }
}
