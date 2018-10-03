using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta : Estructura {

	public float tiempo;

	public GameObject bullet;
	Vector3 bulletPos;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	public float positionY = 0.5f;

	private float startTime;

	private void Start()
	{
		nextFire = Time.time + nextFire;
	}

	private void Update()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			fire();
		}
	}

	private void fire()
	{
		bulletPos = transform.position;
		bulletPos += new Vector3(1f, positionY,0);
		Instantiate(bullet, bulletPos, Quaternion.identity);
	}

	private void FixedUpdate()
	{
		tiempo = tiempo - Time.deltaTime;
	}
}
