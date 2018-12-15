﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    private string nombreEscena;
    public GameObject transicion;
    void Start()
    {
    }
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(nombreEscena);
    }
    /// <summary>
    /// Logica correspondiente a las seleccion de las distintas opciones del menu principal
    /// </summary>
    void Update()
    {
        RaycastHit2D hit;
        if (Input.touchCount < 1)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
       // Ray ray = Camera.main.ScreenPointToRay(touch.position);
        Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
        hit = Physics2D.Raycast(test, (touch.position));
        if (touch.phase == TouchPhase.Ended)
        {
            if (hit.collider!=null)
            {
                if (hit.transform.tag == "Jugar")
                {
                    nombreEscena = "Partida";
                    StartCoroutine(LoadScene());
                }
                else if(hit.transform.tag=="Opciones")
                {

                } else if (hit.transform.tag == "JugarSolo")
                {
                    nombreEscena = "PartidaSolo";
                    StartCoroutine(LoadScene());
                }
				else if (hit.transform.tag == "Cartas")
				{
                    nombreEscena = "Cartas";
                    StartCoroutine(LoadScene());
                }
				else if(hit.transform.tag=="Salir")
                {
					PlayerPrefs.SetString("token", "");
                    nombreEscena = "UsuarioAcceso";
                    StartCoroutine(LoadScene());
                }
			}
        }
    }
}