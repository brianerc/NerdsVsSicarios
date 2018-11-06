using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaPunkGirlV1 : Hoja {

    private PunkGirlV1 punkGirl;

    public HojaPunkGirlV1(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "PunkGirl V1";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        punkGirl = objeto.GetComponent<PunkGirlV1>();
        punkGirl.SetDaño(4);
        punkGirl.SetVida(10);
        punkGirl.SetVelocidad(-2f);
        punkGirl.SetCostoEnergia(50);
    }
}
