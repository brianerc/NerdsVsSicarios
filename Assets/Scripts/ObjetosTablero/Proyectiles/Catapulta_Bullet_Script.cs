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

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Sicario")
		{
			Debug.Log("Sicario le pego");
			Debug.Log(danoBase);
			Sicario enemigo = other.gameObject.GetComponent<Sicario>();
			enemigo.Herir(danoBase);
			Destruir();
		}
	}

	protected virtual void Destruir()
	{
		Destroy(this.gameObject);
	}
}
