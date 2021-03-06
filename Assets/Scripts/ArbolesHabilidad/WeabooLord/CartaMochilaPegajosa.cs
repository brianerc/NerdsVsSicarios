﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase encargada de mantener la hoja de habilidad de la mochila pegajosa. Se espera iterar sobre esta
/// en la segunda entrega
/// </summary>
public class CartaMochilaPegajosa : Carta {
    private MochilaPegajosa mochilaPegajosa;
    public CartaMochilaPegajosa(GameObject unObjeto)
    {
        nombre = "Mochila pegajosa";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        mochilaPegajosa = unObjeto.GetComponent<MochilaPegajosa>();
        mochilaPegajosa.SetCostoEnergia(50);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
    public override bool EsEstructura()
    {
        return true;
    }
}