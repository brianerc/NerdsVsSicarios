using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase encargada de mantener la hoja de habilidad de la mochila pegajosa. Se espera iterar sobre esta
/// en la segunda entrega
/// </summary>
public class HojaMochilaPegajosa : Hoja {
    private MochilaPegajosa mochilaPegajosa;
    public HojaMochilaPegajosa(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Mochila pegajosa";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        mochilaPegajosa = unObjeto.GetComponent<MochilaPegajosa>();
        mochilaPegajosa.SetearTiempoParalizar(2);
        mochilaPegajosa.SetVida(1);
        mochilaPegajosa.SetCostoEnergia(50);
    }
    public override bool EsEstructura()
    {
        return true;
    }
}