using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaPunkGirlV1 : Carta {

    private PunkGirlV1 punkGirl;

    public CartaPunkGirlV1(GameObject unObjeto)
    {
        nombre = "Punk Girl Base";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        punkGirl = objeto.GetComponent<PunkGirlV1>();
        punkGirl.SetVelocidad(-2f);
        punkGirl.SetCostoEnergia(25);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
