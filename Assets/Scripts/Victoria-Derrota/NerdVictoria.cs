using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NerdVictoria : FinalPartida
{
    private void Start()
    {
        Debug.Log("Experiencia mj" + ComenzarPartidaSolo.cantidadExp);
        GameObject.FindGameObjectWithTag("MostrarInformacion").GetComponent<Text>().text = ComenzarPartidaSolo.cantidadExp + "EXP";
        GanarPuntos();
    }
}
