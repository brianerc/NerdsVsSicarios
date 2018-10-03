using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaJugadorDeFootballV1 : Hoja {

    private JugadorDeFootballV1 jugador;
    // Use this for initialization

    public HojaJugadorDeFootballV1(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football V1";
        descripcion = "";
        aprendida = true;
        jugador = unObjeto.GetComponent<JugadorDeFootballV1>();
        jugador.SetDaño(2);
        jugador.SetVida(10);
        jugador.SetTiempo(1);
        jugador.SetVelocidad(-4f);
        objeto = unObjeto;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
