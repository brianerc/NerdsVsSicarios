using Assets.Scripts.ObjetosTablero.Proyectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta_Bullet_Script : MonoBehaviour {

	public float velocidad = 5f;
	Rigidbody2D rb;
	public float danoBase;

	public bool startMoving;
	public Vector2 velocity;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		startMoving = false;
	}

	private void Update()
	{
		if (startMoving)
		{
			rb.velocity = transform.right * 5f;
			
		} 
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Sicario")
		{
			Debug.Log("Sicario le pego");
			Debug.Log(danoBase);
			Sicario enemigo = collision.gameObject.GetComponent<Sicario>();
			enemigo.Herir(danoBase);
			Destruir();
		}
	}

	protected virtual void Destruir()
	{
		Destroy(this.gameObject);
	}

	internal void PosicionarInicio(Vector3 bulletPos)
	{
		transform.position = bulletPos;
	}

	public void EmpezarAMoverse()
	{
		gameObject.SetActive(true);
		this.startMoving = true;
	}
}
