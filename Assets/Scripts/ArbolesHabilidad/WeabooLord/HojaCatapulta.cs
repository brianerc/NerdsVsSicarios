using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaCatapulta: Hoja {

    private Catapulta catapulta;
    // Use this for initialization
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
