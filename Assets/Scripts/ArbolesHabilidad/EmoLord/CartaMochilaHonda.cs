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
		private MochilaHonda mochilaHonda;

		public CartaMochilaHonda(GameObject unObjeto)
		{
			nivel = 1;
			nombre = "Mochila Honda";
			descripcion = "";
			mochilaHonda = unObjeto.GetComponent<MochilaHonda>();
			objeto = unObjeto;
			mochilaHonda.SetVida(25);
			mochilaHonda.SetCostoEnergia(75);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}
}
