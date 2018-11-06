using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaPunkGirlV2 : Hoja {

    private PunkGirlV2 punkGirl;

    public HojaPunkGirlV2(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "PunkGirl V2";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        punkGirl = objeto.GetComponent<PunkGirlV2>();
        punkGirl.SetDaño(4);
        punkGirl.SetVida(10);
        punkGirl.SetVelocidad(-2f);
        punkGirl.SetCostoEnergia(50);
    }
}
