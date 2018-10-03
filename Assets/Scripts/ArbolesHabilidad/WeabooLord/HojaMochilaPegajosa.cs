using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaMochilaPegajosa : Hoja {
    private MochilaPegajosa mochilaPegajosa;
    // Use this for initialization
    public HojaMochilaPegajosa(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Mochila pegajosa";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        mochilaPegajosa = unObjeto.GetComponent<MochilaPegajosa>();
        mochilaPegajosa.SetTiempoParalizar(2);
        mochilaPegajosa.SetVida(1);
    }
    public override bool EsEstructura()
    {
        return true;
    }
}