using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ArbolesHabilidad.ITGuy
{
	class CartaDroneVolador : Carta
	{
		private DroneVolador droneVolador;

		public CartaDroneVolador(GameObject unObjeto)
		{
			nivel = 1;
			nombre = "Drone Idle";
			descripcion = "";
			droneVolador = unObjeto.GetComponent<DroneVolador>();
			objeto = unObjeto;
			droneVolador.SetVida(25);
			droneVolador.SetCostoEnergia(75);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}
}
