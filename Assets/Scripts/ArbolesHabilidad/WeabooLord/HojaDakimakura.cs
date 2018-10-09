using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaDakimakura : Hoja {

    private Dakimakura dakimakura;
    // Use this for initialization
    public HojaDakimakura(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Dakimakura";
        descripcion = "";
        dakimakura = unObjeto.GetComponent<Dakimakura>();
        objeto = unObjeto;
        dakimakura.SetDanoBase(1);
        dakimakura.SetVida(25);
        dakimakura.SetTiempoAtaque(1);
        dakimakura.SetCostoEnergia(75);
    }
    public override bool EsEstructura()
    {
        return true;
    }
}