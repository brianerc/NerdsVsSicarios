using Assets.Scripts.ObjetosTablero.Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ArbolesHabilidad.EmoLord
{
	class CartaMochilaSierra : Carta
	{
		private MochilaSierra mochilaSierra;

		public CartaMochilaSierra(GameObject unObjeto)
		{
			nivel = 1;
			nombre = "Mochila cierra";
			descripcion = "";
			mochilaSierra = unObjeto.GetComponent<MochilaSierra>();
			objeto = unObjeto;
			mochilaSierra.SetDanoBase(1);
			mochilaSierra.SetVida(25);
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
}
