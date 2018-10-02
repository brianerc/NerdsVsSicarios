using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaJugadorDeFootballV2 : Hoja {

    private JugadorDeFootballV2 jugador;

    public HojaJugadorDeFootballV2(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football V2";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        jugador = objeto.GetComponent<JugadorDeFootballV2>();
        jugador.SetDaño(4);
        jugador.SetVida(10);
        jugador.SetTiempo(1);
        jugador.SetVelocidad(-2f);
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
