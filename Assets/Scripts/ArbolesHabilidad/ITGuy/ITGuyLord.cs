using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ArbolesHabilidad.ITGuy
{
	class ITGuyLord : MazoNerd
	{
		public GameObject droneElectrico;
		public GameObject dakimakura;
		public GameObject mochilaPegajosa;

		protected override void Inicializar()
		{
			vidaBase = 50;
			danoBase = 5;
			tiempo = 1;
			tiempoBase = 1;
			mazo = new List<Carta>();
			energia = 100;
			cantidadRegeneracionEnergia = 30;
			tiempoRegeneracionEnergia = 5;
			droneElectrico.GetComponent<ObjetoTablero>().nivel = 1;
			dakimakura.GetComponent<ObjetoTablero>().nivel = 1;
			mochilaPegajosa.GetComponent<ObjetoTablero>().nivel = 1;
			InsertarCarta(new CartaDroneElectrico(droneElectrico));
			InsertarCarta(new CartaMochilaPegajosa(mochilaPegajosa));
			InsertarCarta(new CartaDakimakura(dakimakura));
			MostrarLanzadores();

		}
	}
}
