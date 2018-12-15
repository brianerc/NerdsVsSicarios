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
	// Use this for initialization
	void Start () {
        Instantiate(fondo);
        Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(jugador2);
        Instantiate(energiaNerd);
        Instantiate(energiaSicario);
	}
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
    }
    // Update is called once per frame
    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().GetVida()<=0)
        {
            nombreEscena = "Nerd_Derrota";
            StartCoroutine(LoadScene());
        }
    }
}
