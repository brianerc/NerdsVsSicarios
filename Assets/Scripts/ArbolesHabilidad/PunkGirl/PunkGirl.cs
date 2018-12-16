using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkGirl : Mazo {

    public GameObject punkGirlBase;
    public GameObject punkGirlV1;
    public GameObject punkGirlV2;

    protected override void Inicializar()
    {
        posicionX = (-posicionX);
        nombre = "Punk Girl";
        descripcion = "";
        energia = 100;
        cantidadRegeneracionEnergia = 30;
        tiempoRegeneracionEnergia = 5;
        mazo = new List<Carta>();

        InsertarCarta(new CartaPunkGirlBase(punkGirlBase));
        InsertarCarta(new CartaPunkGirlV2(punkGirlV2));
        InsertarCarta(new CartaPunkGirlV1(punkGirlV1));

        MostrarLanzadores();

    }

}
