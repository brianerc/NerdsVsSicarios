using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaBailarinV1 : Carta
{

    private BailarinV1 bailarinV1;

    public CartaBailarinV1(GameObject unObjeto)
    {
        nombre = "Bailarín Medio";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        bailarinV1 = objeto.GetComponent<BailarinV1>();
        bailarinV1.SetCostoEnergia(50);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
