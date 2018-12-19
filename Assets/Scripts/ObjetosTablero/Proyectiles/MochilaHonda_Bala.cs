using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


	class MochilaHonda_Bala : MonoBehaviour
	{
		public float velocidad = 5f;
		Rigidbody2D rb;
		public float danoBase;
		public bool empezarAMoverse;
		public Vector2 velocity;

		private void Start()
		{
			rb = GetComponent<Rigidbody2D>();
			empezarAMoverse = false;
		}

		private void Update()
		{
			if (empezarAMoverse)
			{
				rb.velocity = transform.right * 5f;
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.transform.tag == "Sicario")
			{
				Sicario enemigo = collision.gameObject.GetComponent<Sicario>();
				enemigo.Herir(danoBase);
				this.transform.localScale = new Vector2(0, 0);
			}
		}

		/// <summary>
		/// Cuando corresponda, reutiliza la bala seteandose en la posicion de inicio que es donde 
		/// se encuentra la catapulta
		/// </summary>
		/// <param name="bulletPos"></param>
		internal void PosicionarInicio(Vector3 bulletPos)
		{
			transform.position = bulletPos;
		}

		public void EmpezarAMoverse()
		{
			gameObject.SetActive(true);
			this.empezarAMoverse = true;
		}
	}

