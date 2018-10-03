using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuPrincipal : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
                Debug.Log(hit.transform.GetComponent<Text>().text);
                Debug.Log(hit.transform.tag);

                if (hit.transform.tag == "GameController")
                {
                    Debug.Log("Toque");
                    Debug.Log(hit.transform.GetComponent<Text>().text);
                    switch(hit.transform.GetComponent<Text>().text)
                    {
                        case "Jugar":
                            Application.LoadLevel("Partida");
                            break;
                        case "Opciones":
                            break;
                        case "Salir":
                            Application.Quit();
                            break;
                    }
                }
            }
        }
    }
}
