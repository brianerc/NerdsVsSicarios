using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente al jugador nerd "maestro". Este es el personaje princial de los nerds y en esta 
/// clase se mantiene la logica correspondiente a el
/// </summary>
public class WeeabooLord : MazoNerd {
    public GameObject catapulta;
    public GameObject dakimakura;
    public GameObject mochilaPegajosa;

    protected override void Inicializar () {
        factorMultiplicacionDano = 1;
        factorMultiplicacionVida = 3;
        vidaBase = 50;
        danoBase = 5;
        tiempo = 1;
        tiempoBase = 1;
        mazo = new List<Carta>();
        energia = 100;
		nombre = "weaboo";
        cantidadRegeneracionEnergia = 30;
        tiempoRegeneracionEnergia = 5;
        catapulta.GetComponent<ObjetoTablero>().nivel = 1;
        dakimakura.GetComponent<ObjetoTablero>().nivel = 1;
        mochilaPegajosa.GetComponent<ObjetoTablero>().nivel = 1;
        InsertarCarta(new CartaCatapulta(catapulta));
        InsertarCarta(new CartaMochilaPegajosa(mochilaPegajosa));
        InsertarCarta(new CartaDakimakura(dakimakura));
        MostrarLanzadores();
        
    }
}