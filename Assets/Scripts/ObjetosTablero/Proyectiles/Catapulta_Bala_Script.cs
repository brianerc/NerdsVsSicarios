using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta_Bala_Script : MonoBehaviour {

	public float velocidad = 5f;
	Rigidbody2D rb;
	public float danoBase;
	public bool empezarAMoverse;
	public Vector2 velocity;
	public AudioSource ataqueSonido;

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
			if (ataqueSonido != null)
			{
				ataqueSonido.Play();
			}
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
