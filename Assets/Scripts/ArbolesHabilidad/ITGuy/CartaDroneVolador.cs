using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


	class CartaDroneVolador : Carta
	{
		private DroneVolador droneVolador;

		public CartaDroneVolador(GameObject unObjeto)
		{
			nombre = "Drone Idle";
			descripcion = "";
			droneVolador = unObjeto.GetComponent<DroneVolador>();
			objeto = unObjeto;
			droneVolador.SetCostoEnergia(75);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}

