using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta_Bullet_Script : MonoBehaviour {

	public float veltX = 5f;
	float velY = 0f;
	Rigidbody rb;
	public float danoBase;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		rb.velocity = new Vector3(veltX, velY,0);
		Destroy(gameObject, 3f);
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.transform.tag == "Sicario")
		{
			Sicario enemigo = collision.gameObject.GetComponent<Sicario>();
			enemigo.Herir(danoBase);
		}
	}

}
