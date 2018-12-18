using Assets.Scripts.ObjetosTablero.Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ArbolesHabilidad.EmoLord
{
	class CartaMochilaHonda : Carta
	{
		private MochilaHonda mochilaSierra;

		public CartaMochilaHonda(GameObject unObjeto)
		{
			nivel = 1;
			nombre = "Mochila Honda";
			descripcion = "";
			mochilaSierra = unObjeto.GetComponent<MochilaHonda>();
			objeto = unObjeto;
			mochilaSierra.SetDanoBase(1);
			mochilaSierra.SetVida(25);
			mochilaSierra.SetTiempoAtaque(1);
			mochilaSierra.SetCostoEnergia(75);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}
}
