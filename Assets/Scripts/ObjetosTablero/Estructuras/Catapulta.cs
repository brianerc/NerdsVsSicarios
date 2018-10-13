using Assets.Scripts.ObjetosTablero.Proyectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta : Estructura
{

	public float tiempo;
	public AudioClip clip;
	public Catapulta_Bullet_Script bullet;
	Vector3 bulletPos;
	public float freqDeDisparo;
	public float siguienteDisparo;
	public float posicionY;

	private Vector3 vector;
	private float startTime;
	private Vector3 posInicial;

	private List<Catapulta_Bullet_Script> bullets;
	private int balaNum;

	private Catapulta_Bullet_Script bala1;
	private Catapulta_Bullet_Script bala2;
	private Catapulta_Bullet_Script bala3;
	private Grid matriz;
	private Animator animator;


	private void Start()
	{
		animator = GetComponent<Animator>();
		matriz = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		balaNum = 0;
		siguienteDisparo = Time.time + siguienteDisparo;
		vector = new Vector3(1f, posicionY, 0);
		posInicial = transform.position;
		this.bullets = new List<Catapulta_Bullet_Script>();
		bulletPos = transform.position;
		bulletPos += vector;

		bala1 = Instantiate(bullet, bulletPos, Quaternion.identity);
		bala2 = Instantiate(bullet, bulletPos, Quaternion.identity);
		bala3 = Instantiate(bullet, bulletPos, Quaternion.identity);

		bala1.transform.localScale = new Vector2(0, 0);
		bala2.transform.localScale = new Vector2(0, 0);
		bala3.transform.localScale = new Vector2(0, 0);
	}

	private void FixedUpdate()
	{
		tiempo = tiempo - Time.deltaTime;

		Vector3Int auxiliar = matriz.WorldToCell(this.transform.position);
		if (Filas.HaySicarioEnFila(auxiliar.y))
		{
			animator.SetBool("tiene_enemigo_en_fila", true);
		}
		else
		{
			animator.SetBool("tiene_enemigo_en_fila", false);
		}
	}

	private void Fire()
	{

		switch (balaNum)
		{
			case 0:
				bala1.transform.localScale = new Vector2(1, 1);
				bala1.transform.position = bulletPos;
				bala1.startMoving = true;
				bala1.EmpezarAMoverse();
				bala1.PosicionarInicio(bulletPos);
				break;
			case 1:
				bala2.transform.localScale = new Vector2(1, 1);
				bala2.transform.position = bulletPos;

				bala2.startMoving = true;
				bala2.EmpezarAMoverse();
				bala2.PosicionarInicio(bulletPos);
				break;
			case 2:
				bala3.transform.localScale = new Vector3(1, 1);
				bala3.transform.position = bulletPos;
				bala3.startMoving = true;
				bala3.EmpezarAMoverse();
				bala3.PosicionarInicio(bulletPos);
				break;
		}
		balaNum = ++balaNum % 2;

	}

	private void Destruirse()
	{
		Destroy(bala1.gameObject);
		Destroy(bala2.gameObject);
		Destroy(bala3.gameObject);
		Destroy(this.gameObject);
	}

	private void ReproducirSonido()
	{
		AudioSource audio = this.gameObject.GetComponent<AudioSource>();
		audio.PlayOneShot(audio.clip);
	}
}
