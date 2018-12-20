using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase encargada de mantener la hoja de habilidad de la catapulta. Se espera iterar sobre estas habilidades
/// en la segunda entrega
/// </summary>
public class CartaCatapulta: Carta {

    private Catapulta catapulta;

	public CartaCatapulta (GameObject unObjeto) {
        nombre = "Catapulta";
        descripcion = "";
		catapulta = unObjeto.GetComponent<Catapulta>();
		objeto = unObjeto;
        catapulta.SetCostoEnergia(25);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
    public override bool EsEstructura()
    {
        return true;
    }
}
