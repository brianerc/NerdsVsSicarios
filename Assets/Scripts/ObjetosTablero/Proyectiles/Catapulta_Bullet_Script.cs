using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta_Bullet_Script : MonoBehaviour {

	public float veltX = 5f;
	float velY = 0f;
	Rigidbody2D rb;
	public float danoBase;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		rb.velocity = new Vector2(veltX, velY);
		Destroy(gameObject, 3f);
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
}
