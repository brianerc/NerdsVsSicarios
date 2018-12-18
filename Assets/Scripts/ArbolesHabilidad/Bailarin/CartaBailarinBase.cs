using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaBailarinBase : Carta
{

    private BailarinBase bailarinBase;

    public CartaBailarinBase(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Bailarín Estrella";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        bailarinBase = objeto.GetComponent<BailarinBase>();
        bailarinBase.SetDaño(4);
        bailarinBase.SetVida(10);
        bailarinBase.SetVelocidad(-2f);
        bailarinBase.SetCostoEnergia(75);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
