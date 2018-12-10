using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaPunkGirlBase : Carta
{
    // Use this for initialization
    private PunkGirlBase punkGirl;

    public CartaPunkGirlBase(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Punk Girl Estrella";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        punkGirl = objeto.GetComponent<PunkGirlBase>();
        punkGirl.SetDaño(4);
        punkGirl.SetVida(10);
        punkGirl.SetVelocidad(-2f);
        punkGirl.SetCostoEnergia(50);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
