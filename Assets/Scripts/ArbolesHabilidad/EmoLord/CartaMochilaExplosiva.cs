using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


	class CartaMochilaExplosiva : Carta
	{
		private MochilaExplosiva mochilaExplosiva;

		public CartaMochilaExplosiva(GameObject unObjeto)
		{
			nombre = "Mochila Mina";
			descripcion = "";
			mochilaExplosiva = unObjeto.GetComponent<MochilaExplosiva>();
			objeto = unObjeto;
			mochilaExplosiva.SetTiempoAtaque(1);
			mochilaExplosiva.SetCostoEnergia(50);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}

