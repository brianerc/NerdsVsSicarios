using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase encargada de mantener la hoja de habilidad del dakimakura. Se espera iterar sobre esta en la 
/// segunda entrega
/// </summary>
public class CartaDakimakura : Carta {

    private Dakimakura dakimakura;

	public CartaDakimakura(GameObject unObjeto)
    {
        nombre = "Dakimakura";
        descripcion = "";
        dakimakura = unObjeto.GetComponent<Dakimakura>();
        objeto = unObjeto;
        dakimakura.SetTiempoAtaque(1);
        dakimakura.SetCostoEnergia(75);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
    public override bool EsEstructura()
    {
        return true;
    }
}