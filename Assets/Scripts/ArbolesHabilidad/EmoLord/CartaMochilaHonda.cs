using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


	class CartaMochilaHonda : Carta
	{
		private MochilaHonda mochilaHonda;

		public CartaMochilaHonda(GameObject unObjeto)
		{
			nombre = "Mochila Honda";
			descripcion = "";
			mochilaHonda = unObjeto.GetComponent<MochilaHonda>();
			objeto = unObjeto;
			mochilaHonda.SetCostoEnergia(75);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}

