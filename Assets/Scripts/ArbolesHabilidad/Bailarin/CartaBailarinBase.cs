using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaBailarinBase : Carta
{

    private BailarinBase bailarinBase;

    public CartaBailarinBase(GameObject unObjeto)
    {
        nombre = "Bailarín Estrella";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        bailarinBase = objeto.GetComponent<BailarinBase>();
        bailarinBase.SetCostoEnergia(75);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
