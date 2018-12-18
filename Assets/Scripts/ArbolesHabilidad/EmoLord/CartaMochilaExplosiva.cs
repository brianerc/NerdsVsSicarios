using Assets.Scripts.ObjetosTablero.Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ArbolesHabilidad.EmoLord
{
	class CartaMochilaExplosiva : Carta
	{
		private MochilaExplosiva mochilaExplosiva;

		public CartaMochilaExplosiva(GameObject unObjeto)
		{
			nivel = 1;
			nombre = "Mochila Mina";
			descripcion = "";
			mochilaExplosiva = unObjeto.GetComponent<MochilaExplosiva>();
			objeto = unObjeto;
			mochilaExplosiva.SetDanoBase(100);
			mochilaExplosiva.SetVida(25);
			mochilaExplosiva.SetTiempoAtaque(1);
			mochilaExplosiva.SetCostoEnergia(75);
			unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
			unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
		}
		public override bool EsEstructura()
		{
			return true;
		}
	}
}
