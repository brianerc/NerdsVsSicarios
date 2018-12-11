using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaBailarinV2 : Carta
{

    private BailarinV2 bailarinV2;

    public CartaBailarinV2(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Bailarín Base";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        bailarinV2 = objeto.GetComponent<BailarinV2>();
        bailarinV2.SetDaño(4);
        bailarinV2.SetVida(10);
        bailarinV2.SetVelocidad(-2f);
        bailarinV2.SetCostoEnergia(50);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
}
