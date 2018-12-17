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

		private void OnCollisionStay2D(Collision2D collision)
		{
			if (collision.transform.tag == "Sicario")
			{
				tiempo = tiempo - Time.deltaTime;
				Sicario enemigo = collision.gameObject.GetComponent<Sicario>();
				if (tiempo <= 0 && vidaBase > 0)
				{
					enemigo.Herir(danoBase);
					sonidoAtaque.Play();
					tiempo = 1;
				}
			}
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
