using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaMochilaPegajosa : Hoja {
    private double dañoBase;
    private double cd;
    private double vida;
    private GameObject objeto;
    // Use this for initialization
    public HojaMochilaPegajosa(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Mochila pegajosa";
        descripcion = "";
        dañoBase = 2;
        cd = 2.5;
        vida = 3;
        aprendida = true;
        objeto = unObjeto;
    }
    public override bool EsEstructura()
    {
        return true;
    }
}