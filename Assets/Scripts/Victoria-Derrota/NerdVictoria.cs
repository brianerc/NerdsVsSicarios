using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Logica correspondiente a cuando el nerd obtiene la victoria. En la mismas se implementara 
/// lo correspondiente para aumentar el arbol de habilidad del mismo 
/// </summary>
public class NerdVictoria : FinalPartida
{
    public GameObject transicion;
    private string nombreEscena;
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
    }
    private void Update()
    {
        if (Input.touchCount < 1)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Input.GetTouch(0).position);

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider && hit.collider.tag == this.gameObject.tag)
            {
                nombreEscena = "MenuPrincipal";
                StartCoroutine(LoadScene());
            }
        }
    }

}
