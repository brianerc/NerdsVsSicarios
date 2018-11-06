using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaPunkGirlBase : Hoja
{
    // Use this for initialization
    private PunkGirlBase punkGirl;

    public HojaPunkGirlBase(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "PunkGirl Base";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        punkGirl = objeto.GetComponent<PunkGirlBase>();
        punkGirl.SetDaño(4);
        punkGirl.SetVida(10);
        punkGirl.SetVelocidad(-2f);
        punkGirl.SetCostoEnergia(50);
    }
}
