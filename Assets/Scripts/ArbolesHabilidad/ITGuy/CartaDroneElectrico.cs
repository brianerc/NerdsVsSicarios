using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


	class CartaDroneElectrico : Carta
	{
		private DroneElectrico droneElectrico;

		public CartaDroneElectrico(GameObject unObjeto)
		{
			nombre = "Drone 2.0 Idle";
			descripcion = "";
			droneElectrico = unObjeto.GetComponent<DroneElectrico>();
			objeto = unObjeto;
			droneElectrico.SetTiempoAtaque(1);
			droneElectrico.SetCostoEnergia(50);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}

