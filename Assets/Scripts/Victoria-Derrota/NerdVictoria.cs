using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NerdVictoria : FinalPartida
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("MostrarInformacion").GetComponent<Text>().text = "You win " + ComenzarPartidaSolo.cantidadExp + "EXP";
        //GanarPuntos();
    }
}
