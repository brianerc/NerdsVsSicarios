using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase encargada de mantener la hoja de habilidad de la catapulta. Se espera iterar sobre estas habilidades
/// en la segunda entrega
/// </summary>
public class HojaCatapulta: Hoja {

    private Catapulta catapulta;

	public HojaCatapulta (GameObject unObjeto) {
        nivel = 1;
        nombre = "Catapulta";
        descripcion = "";
		//aprendida = true;
		catapulta = unObjeto.GetComponent<Catapulta>();
		objeto = unObjeto;
		//catapulta.SetVida(20);
        catapulta.SetCostoEnergia(25);
	}
    public override bool EsEstructura()
    {
        return true;
    }
}
