using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaJugadorDeFootballBase : Hoja
{

    private double dañoBase;
    private double cd;
    private double vida;
    private GameObject objeto;

    // Use this for initialization
    public HojaJugadorDeFootballBase(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football Base";
        descripcion = "";
        dañoBase = 2;
        cd = 2.5;
        vida = 3;
        aprendida = true;
        objeto = unObjeto;
    }
    public override bool EsEstructura()
    {
        return true;
    }
}
