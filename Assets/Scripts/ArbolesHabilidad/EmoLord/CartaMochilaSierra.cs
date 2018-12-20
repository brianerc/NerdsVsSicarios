using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


	class CartaMochilaSierra : Carta
	{
		private MochilaSierra mochilaSierra;

		public CartaMochilaSierra(GameObject unObjeto)
		{
			nombre = "Mochila cierra";
			descripcion = "";
			mochilaSierra = unObjeto.GetComponent<MochilaSierra>();
			objeto = unObjeto;
			mochilaSierra.SetTiempoAtaque(1);
			mochilaSierra.SetCostoEnergia(25);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}

