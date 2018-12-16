using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bailarin : Mazo
{

    public GameObject bailarinBase;
    public GameObject bailarinV1;
    public GameObject bailarinV2;

    protected override void Inicializar()
    {
        posicionX = (-posicionX);
        nombre = "Bailarin";
        descripcion = "";
        energia = 100;
        cantidadRegeneracionEnergia = 30;
        tiempoRegeneracionEnergia = 5;
        mazo = new List<Carta>();
        InsertarCarta(new CartaBailarinBase(bailarinBase));
        InsertarCarta(new CartaBailarinV1(bailarinV1));
        InsertarCarta(new CartaBailarinV2(bailarinV2));


        MostrarLanzadores();

    }

}