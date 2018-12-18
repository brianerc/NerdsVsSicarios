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
        int numero = Random.Range(1, 3);
       
        if(numero==1)
        {
            fondo.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Arcade");
            GameObject.Find("Barricada").GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("Sprites/Partida/Barrera_Arcade");
        }
        else if (numero == 2)
        {
            fondo.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Callejon");
            GameObject.Find("Barricada").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Callejon");

        }
        else
        {
            fondo.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Parque");
            GameObject.Find("Barricada").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Barrera_Parque");
        }
    }
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(nombreEscena);
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
