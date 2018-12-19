using Assets.Scripts.ObjetosTablero.Proyectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta : Estructura
{
	public float tiempo;
	public AudioClip clip;
	public Catapulta_Bala_Script bullet;
	Vector3 balaPosicion;
	public float freqDeDisparo;
	public float siguienteDisparo;
	public float posicionY;

	private Vector3 vector;
	private float startTime;
	private Vector3 posInicial;

	private int balaNum;

	//Se utilizan tres balas las cuales reutilizamos para no tener que estar creando y destruyendo cada una
	private Catapulta_Bala_Script bala1;
	private Catapulta_Bala_Script bala2;
	private Catapulta_Bala_Script bala3;
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
		balaPosicion = transform.position;
		balaPosicion += vector;

		//Se instancian solo una vez las 3 balas
		bala1 = Instantiate(bullet, balaPosicion, Quaternion.identity);
		bala2 = Instantiate(bullet, balaPosicion, Quaternion.identity);
		bala3 = Instantiate(bullet, balaPosicion, Quaternion.identity);

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

	//Metodo que se llama desde la animacion de la catapulta. Esto es para que la catapulta dispare justo
	//cuando lo hace en la animacion. De esta forma optimizamos el momento de disparo
	private void Fire()
	{
		switch (balaNum)
		{
			case 0:
				bala1.transform.localScale = new Vector2(1, 1);
				bala1.transform.position = balaPosicion;
				bala1.empezarAMoverse = true;
				bala1.EmpezarAMoverse();
				bala1.PosicionarInicio(balaPosicion);
				break;
			case 1:
				bala2.transform.localScale = new Vector2(1, 1);
				bala2.transform.position = balaPosicion;

				bala2.empezarAMoverse = true;
				bala2.EmpezarAMoverse();
				bala2.PosicionarInicio(balaPosicion);
				break;
			case 2:
				bala3.transform.localScale = new Vector3(1, 1);
				bala3.transform.position = balaPosicion;
				bala3.empezarAMoverse = true;
				bala3.EmpezarAMoverse();
				bala3.PosicionarInicio(balaPosicion);
				break;
		}
		balaNum = ++balaNum % 2;
	}

	new 
	public void Morir()
	{
		base.Morir();
		Destroy(bala1.gameObject);
		Destroy(bala2.gameObject);
		Destroy(bala3.gameObject);
	}

	private void ReproducirSonido()
	{
		AudioSource audio = this.gameObject.GetComponent<AudioSource>();
		audio.PlayOneShot(audio.clip);
	}
}
