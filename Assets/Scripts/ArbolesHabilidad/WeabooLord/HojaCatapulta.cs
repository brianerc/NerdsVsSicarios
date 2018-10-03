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
        aprendida = true;
        objeto = unObjeto;
        catapulta = unObjeto.GetComponent<Catapulta>();
	}
    public override bool EsEstructura()
    {
        return true;
    }
}
