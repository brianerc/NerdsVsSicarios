using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ObjetosTablero.Estructuras
{
	public class EstructuraComportamientoComun : Estructura
	{
		public float tiempo;
		private AudioSource sonidoAtaque;

		private void Start()
		{
			sonidoAtaque = GetComponent<AudioSource>();
		}

		private void FixedUpdate()
		{
		}

		public void SetDanoBase(float dano)
		{
			danoBase = dano;
		}

		public void SetTiempoAtaque(float unTiempo)
		{
			tiempo = unTiempo;
		}

		public float GetTiempo()
		{
			return danoBase;
		}
	}
}
