using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{

    void Start()
    {
    }

	/// <summary>
	/// Logica correspondiente a las seleccion de las distintas opciones del menu principal
	/// </summary>
    void Update()
    {
        RaycastHit hit;
        if (Input.touchCount < 1)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (touch.phase == TouchPhase.Ended)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Jugar")
                {
                    SceneManager.LoadScene("Partida",LoadSceneMode.Single);
                }
                else if(hit.transform.tag=="Opciones")
                {

                } else if (hit.transform.tag == "JugarSolo")
                {
                    SceneManager.LoadScene("PartidaSolo", LoadSceneMode.Single);
                }
                else if(hit.transform.tag=="Salir")
                {
                    Application.Quit();
                }
            }
        }
    }
}