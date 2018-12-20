using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaPunkGirlBase : Carta
{
    // Use this for initialization
    private PunkGirlBase punkGirl;

    public CartaPunkGirlBase(GameObject unObjeto)
    {
        nombre = "Punk Girl Estrella";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        punkGirl = objeto.GetComponent<PunkGirlBase>();
        punkGirl.SetCostoEnergia(75);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
