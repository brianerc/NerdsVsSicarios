﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaPunkGirlV2 : Carta {

    private PunkGirlV2 punkGirl;

    public CartaPunkGirlV2(GameObject unObjeto)
    {
        nombre = "Punk Girl Media";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        punkGirl = objeto.GetComponent<PunkGirlV2>();
        punkGirl.SetCostoEnergia(50);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
