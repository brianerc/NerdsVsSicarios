using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaJugadorDeFootballV1 : Hoja {

    private double dañoBase;
    private double cd;
    private double vida;
    private GameObject objeto;
    // Use this for initialization
    void Start () {
		
	}
    public HojaJugadorDeFootballV1(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football V1";
        descripcion = "";
        dañoBase = 2;
        cd = 2.5;
        vida = 3;
        aprendida = true;
        objeto = unObjeto;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
