using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

	class CartaDroneVentilador : Carta
	{
		private DroneVentilador droneVentilador;

		public CartaDroneVentilador(GameObject unObjeto)
		{
			nivel = 1;
			nombre = "Drone 3.0 Idle";
			descripcion = "";
			droneVentilador = unObjeto.GetComponent<DroneVentilador>();
			objeto = unObjeto;
			droneVentilador.SetDanoBase(1);
			droneVentilador.SetVida(25);
			droneVentilador.SetTiempoAtaque(1);
			droneVentilador.SetCostoEnergia(75);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}

