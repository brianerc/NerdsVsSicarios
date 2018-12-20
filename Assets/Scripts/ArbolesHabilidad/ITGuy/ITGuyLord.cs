using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

	class ITGuyLord : MazoNerd
	{
		public GameObject droneElectrico;
		public GameObject droneVentilador;
		public GameObject droneVolador;

		protected override void Inicializar()
		{
            factorMultiplicacionDano = 2;
            factorMultiplicacionVida = 2;
			vidaBase = 50;
			danoBase = 5;
			tiempo = 1;
			tiempoBase = 1;
			mazo = new List<Carta>();
			energia = 100;
			cantidadRegeneracionEnergia = 30;
			tiempoRegeneracionEnergia = 5;
			droneElectrico.GetComponent<ObjetoTablero>().nivel = 1;
			droneVentilador.GetComponent<ObjetoTablero>().nivel = 1;
			droneVolador.GetComponent<ObjetoTablero>().nivel = 1;

			InsertarCarta(new CartaDroneVolador(droneVolador));
        InsertarCarta(new CartaDroneElectrico(droneElectrico));
        InsertarCarta(new CartaDroneVentilador(droneVentilador));

        MostrarLanzadores();

		}
	}
