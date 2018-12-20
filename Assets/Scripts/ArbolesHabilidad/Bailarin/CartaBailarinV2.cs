using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaBailarinV2 : Carta
{

    private BailarinV2 bailarinV2;

    public CartaBailarinV2(GameObject unObjeto)
    {
        nombre = "Bailarín Base";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        bailarinV2 = objeto.GetComponent<BailarinV2>();
        bailarinV2.SetVelocidad(-2f);
        bailarinV2.SetCostoEnergia(25);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
