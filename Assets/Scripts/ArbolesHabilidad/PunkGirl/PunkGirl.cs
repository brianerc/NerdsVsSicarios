using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkGirl : Arbol {

    public GameObject punkGirlBase;
    public GameObject punkGirlV1;
    public GameObject punkGirlV2;

    protected override void Inicializar()
    {
        posicionX = (-posicionX);
        arbol = new Hoja[5][];
        nombre = "Punk Girl";
        descripcion = "";
        for (int i = 0; i < arbol.Length; i++)
        {
            if (i == 0)
            {
                arbol[i] = new Hoja[3];
            }
            else
            {
                arbol[i] = new Hoja[0];
            }
        }
        energia = 100;
        cantidadRegeneracionEnergia = 30;
        tiempoRegeneracionEnergia = 5;
        InsertarHoja(new HojaPunkGirlBase(punkGirlBase), 0);
        InsertarHoja(new HojaPunkGirlV2(punkGirlV2), 0);
        InsertarHoja(new HojaPunkGirlV1(punkGirlV1), 0);

        MostrarLanzadores();

    }
    protected override GameObject CargarLanzador(int i, int j)
    {
        return arbol[i][j].GetObjeto();
    }
}
