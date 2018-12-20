using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoLord : MazoNerd
{
	public GameObject mochilaSierra;
	public GameObject mochilaHonda;
	public GameObject mochilaExplosiva;

	protected override void Inicializar()
	{
        factorMultiplicacionDano = 3;
        factorMultiplicacionVida = 1;
        vidaBase = 500;
		nombre = "emo";
		danoBase = 50;
		tiempo = 1;
		tiempoBase = 1;
		mazo = new List<Carta>();
		energia = 100;
		cantidadRegeneracionEnergia = 30;
		tiempoRegeneracionEnergia = 5;
		mochilaSierra.GetComponent<ObjetoTablero>().nivel = 1;
		mochilaHonda.GetComponent<ObjetoTablero>().nivel = 1;
		mochilaExplosiva.GetComponent<ObjetoTablero>().nivel = 1;
		InsertarCarta(new CartaMochilaSierra(mochilaSierra));
		InsertarCarta(new CartaMochilaHonda(mochilaHonda));
		InsertarCarta(new CartaMochilaExplosiva(mochilaExplosiva));
		MostrarLanzadores();
	}
}
